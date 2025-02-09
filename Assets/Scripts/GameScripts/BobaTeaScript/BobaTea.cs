using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BobaTea
{
    public Liquid m_Liquid = Liquid.None;
    public Tapioca m_Tapioca = Tapioca.None;
    public HashSet<Topping> m_Toppings = new HashSet<Topping>();
    public bool m_Lidded = false;

    public BobaTea(Liquid liquid, Tapioca tapioca, HashSet<Topping> toppings) : this() {
        m_Liquid = liquid;
        m_Tapioca = tapioca;
        m_Toppings = toppings;
    }

    public BobaTea(Liquid liquid, Tapioca tapioca, Topping topping) : this(liquid, tapioca, new HashSet<Topping>()) {
        m_Toppings.Add(topping);
    }

    public BobaTea(Liquid liquid, Tapioca tapioca) : this(liquid, tapioca, new HashSet<Topping>()) {}

    public BobaTea() {} // BASE CONSTRUCTOR! Insert code HERE, not above!

    public bool SetLiquid(BobaTea.Liquid i_Liquid) {
        if (!m_Lidded){
            m_Liquid = i_Liquid;
        }
        return !m_Lidded;
    }

    public bool SetTapioca(BobaTea.Tapioca i_Tapioca) {
        if (!m_Lidded){
            m_Tapioca = i_Tapioca;
        }
        return !m_Lidded;
    }

    public bool AddTopping(BobaTea.Topping i_Topping) {
        if (!m_Lidded){
            m_Toppings.Add(i_Topping);
        }
        return !m_Lidded;
    }

    public void AddLid() {
        m_Lidded = true; // No need to check because it can't go false.
    }

    public override bool Equals(object obj)
    {   
        //Debug.Log("USING EQUALITY CHECK");
        if (obj is not BobaTea) return false;
        
        BobaTea otherTea = (BobaTea)obj;
        /*Debug.Log("COMPARISON: Other object " + ((otherTea == null) ? "is" : "is not") + " bobaTea");

        Debug.Log("OtherLiquid = " + otherTea.m_Liquid + ", Liquid = " + m_Liquid);
        Debug.Log("OtherTap = " + otherTea.m_Tapioca + ", Tap = " + m_Tapioca);
        Debug.Log(string.Join(",", otherTea.m_Toppings) + " VS " + string.Join(",", m_Toppings));
        Debug.Log("OtherLid = " + otherTea.m_Lidded +  ", Lid = " + m_Lidded);*/

        return (otherTea.m_Liquid == m_Liquid) && (otherTea.m_Tapioca == m_Tapioca) && otherTea.m_Toppings.SetEquals(m_Toppings) && (otherTea.m_Lidded == m_Lidded);
    }
    

    // TODO - GetHashCode? I don't think it'll be relevant

    public enum Liquid {
        None,
        GreenTea,
        BlackTea,
        Strawberry,
        Matcha,
        Banana,
        Blueberry,
        Peach
    }
    public enum Tapioca {
        None,
        Classic,
        Pineapple,
        Peach,
        Matcha,
        Strawberry,
        Coffee
    }

    public enum Topping {
        Foam
    }
}

public static class EnumExtensions {
    public static Sprite GetSprite(this BobaTea.Liquid self) {
        string spriteResource = "Art/BobaCup/Liquid/";

        switch (self) {
            case BobaTea.Liquid.GreenTea:
                spriteResource += "green";
                break;
            case BobaTea.Liquid.BlackTea:
                spriteResource += "black";
                break;
            case BobaTea.Liquid.Matcha:
                spriteResource += "brown";
                break;
            case BobaTea.Liquid.Strawberry:
                spriteResource += "pink";
                break;
            case BobaTea.Liquid.Peach:
                spriteResource += "peach";
                break;
            case BobaTea.Liquid.Banana:
                spriteResource += "yellow";
                break;
            case BobaTea.Liquid.Blueberry:
                spriteResource += "purple";
                break;
            case BobaTea.Liquid.None:
                spriteResource += "";
                break;
            default:
                Debug.LogError("Attempted to get sprite of liquid with no assigned sprite. Returned null.");
                spriteResource = "";
                break;
        }

        return Resources.Load<Sprite>(spriteResource);
    }

    public static Sprite GetSpriteFloating(this BobaTea.Tapioca self) {
        string spriteResource = "Art/BobaCup/Tapioca/Floating/";

        switch (self) {
            case BobaTea.Tapioca.Classic:
                spriteResource += "purple";
                break;
            case BobaTea.Tapioca.Matcha:
                spriteResource += "matcha";
                break;
            case BobaTea.Tapioca.Coffee:
                spriteResource += "coffee";
                break;
            case BobaTea.Tapioca.Pineapple:
                spriteResource += "yellow";
                break;
            case BobaTea.Tapioca.Strawberry:
                spriteResource += "strawberry";
                break;
            case BobaTea.Tapioca.Peach:
                spriteResource += "peach";
                break;
            case BobaTea.Tapioca.None:
                spriteResource += "";
                break;
            default:
                Debug.LogError("Attempted to get floating sprite of tapioca with no assigned sprite. Returned null.");
                spriteResource = "";
                break;
        }

        return Resources.Load<Sprite>(spriteResource);
    }

    public static Sprite GetSpritePickup(this BobaTea.Tapioca self) {
        string spriteResource = "Art/BobaCup/Tapioca/Pickup/";

        switch (self) {
            case BobaTea.Tapioca.Classic:
                spriteResource += "classic";
                break;
            case BobaTea.Tapioca.Matcha:
                spriteResource += "matcha";
                break;
            case BobaTea.Tapioca.Coffee:
                spriteResource += "coffee";
                break;
            case BobaTea.Tapioca.Pineapple:
                spriteResource += "pineapple";
                break;
            case BobaTea.Tapioca.Strawberry:
                spriteResource += "strawberry";
                break;
            case BobaTea.Tapioca.Peach:
                spriteResource += "peach";
                break;
            case BobaTea.Tapioca.None:
                spriteResource += "";
                break;
            default:
                Debug.LogError("Attempted to get pickup sprite of tapioca with no assigned sprite. Returned null.");
                spriteResource = "";
                break;
        }

        return Resources.Load<Sprite>(spriteResource);
    }

    public static Sprite GetSprite(this BobaTea.Topping self) {
        string spriteResource = "Art/BobaCup/Topping/";

        switch (self) {
            case BobaTea.Topping.Foam:
                spriteResource += "cream_outline";
                break;
            default:
                Debug.LogError("Attempted to get sprite of liquid with no assigned sprite. Returned null.");
                spriteResource = "";
                break;
        }

        return Resources.Load<Sprite>(spriteResource);
    }

}