using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace WpfSample
{
    public class CharacterSheet : Observable
    {
        public CharacterSheet()
        {
            this.AddCharacterCommand = new(() => Characters.Add(new () { Name = GetNewCharacterName()}));
            this.RemoveCharacterCommand = new (ch => Characters.Remove(ch));
        }

        private string GetNewCharacterName()
        {
            var index = 0;
            var name = GetCharacterName(index);
            while (CharacterNameExists(name))
            {
                ++index;
                name = GetCharacterName(index);
            }
            return name;
            static string GetCharacterName(int index) => index == 0 ? "New Character" : $"New Character ({index})";
        }

        private bool CharacterNameExists(string name) => this.Characters.Any(x => x.Name == name);
        public Command AddCharacterCommand { get; }
        public Command<Character> RemoveCharacterCommand { get; }
        public ObservableCollection<Character> Characters { get; } = new();
        private Character? selectedCharacter;
        public Character? SelectedCharacter
        {
            get => this.selectedCharacter;
            set => SetField(ref this.selectedCharacter, value);
        }

    }
}