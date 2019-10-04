using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Survivaria.Items.Food.BiomeSpecific.Purity
{
    public class Guavado : FoodItem
    {
        public Guavado() : base("Guavado", "It has a faint aroma of citrus, and its buttery texture makes it a delicacy.", 24, 30, Item.buyPrice(0, 0, 1, 0), ItemRarityID.Blue, 6, 0, SoundID.Item2)
        {
        }
    }
}