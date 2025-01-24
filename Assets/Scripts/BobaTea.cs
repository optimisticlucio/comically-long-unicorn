using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BobaTea
{
    Liquid m_Liquid = Liquid.None;
    Tapioca m_Tapioca = Tapioca.None;
    List<Topping> m_Toppings = new List<Topping>();
    Foam m_Foam = Foam.None;

    public BobaTea(Liquid liquid, Tapioca tapioca, List<Topping> toppings, Foam foam) : base() {
        m_Liquid = liquid;
        m_Tapioca = tapioca;
        m_Toppings = toppings;
        m_Foam = foam;
    }

    public BobaTea() {} // BASE CONSTRUCTOR! Insert code HERE, not above!

    public override bool Equals(object obj)
    {
        BobaTea otherTea = obj as BobaTea;
        if (otherTea is null) return false;

        return (otherTea.m_Liquid == m_Liquid) && (otherTea.m_Tapioca == m_Tapioca) && otherTea.m_Toppings.SequenceEqual(m_Toppings) && (otherTea.m_Foam == m_Foam);
    }
    

    // TODO - GetHashCode? I don't think it'll be relevant

    public enum Liquid {
        None,
        GreenTea,
        BlackTea,
        Water
    }

    public enum Tapioca {
        None,
        Bubbles
    }

    public enum Topping {
        None
    }

    public enum Foam {
        None
    }
}
