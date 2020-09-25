using Game_Platform.Games.ChemicalHunt.ChemicalElementsApi;

namespace Game_Platform.Games.ChemicalHunt.Models
{
    public class HiddenWord : ChemicalElement
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int FinalX { get; set; }
        public int FinalY { get; set; }
        public Orientation Orientation { get; set; }
        public bool Located { get; set; }
        public bool Reversed { get; set; }

        public HiddenWord(ChemicalElement Element)
        {
            Name = Element.Name;
            Symbol = Element.Symbol;
            AtomicNumber = Element.AtomicNumber;
            Weight = Element.Weight;
            IconPath = Element.IconPath;
            Reversed = false;
            Located = false;
        }
    }

    public enum Orientation
    {
        VERTICAL,
        HORIZONTAL
    }
}
