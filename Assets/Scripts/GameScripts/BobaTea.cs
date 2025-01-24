using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class BobaTea : MonoBehaviour
{
    Liquid m_Liquid = Liquid.None;
    Tapioca m_Tapioca = Tapioca.None;
    List<Topping> m_Toppings = new List<Topping>();
    Foam m_Foam = Foam.None;

    bool m_Lidded = false;

    public BobaTea(Liquid liquid, Tapioca tapioca, List<Topping> toppings, Foam foam) : this() {
        m_Liquid = liquid;
        m_Tapioca = tapioca;
        m_Toppings = toppings;
        m_Foam = foam;
    }

    public BobaTea(Liquid liquid, Tapioca tapioca, Topping topping, Foam foam) : this(liquid, tapioca, new List<Topping>(), foam) {
        m_Toppings.Add(topping);
    }

    public BobaTea() {} // BASE CONSTRUCTOR! Insert code HERE, not above!

    public void SetLiquid(BobaTea.Liquid i_Liquid) {
        if (!m_Lidded){
            m_Liquid = i_Liquid;
        }
    }

    public void SetTapioca(BobaTea.Tapioca i_Tapioca) {
        if (!m_Lidded){
            m_Tapioca = i_Tapioca;
        }
    }

    public void SetFoam(BobaTea.Foam i_Foam) {
        if (!m_Lidded){
            m_Foam = i_Foam;
        }
    }

    public void AddTopping(BobaTea.Topping i_Topping) {
        if (!m_Lidded){
            m_Toppings.Add(i_Topping);
        }
    }

    public void AddLid() {
        m_Lidded = true; // No need to check because it can't go false.
    }

    public override bool Equals(object obj)
    {
        BobaTea otherTea = obj as BobaTea;
        if (otherTea is null) return false;

        return (otherTea.m_Liquid == m_Liquid) && (otherTea.m_Tapioca == m_Tapioca) && otherTea.m_Toppings.SequenceEqual(m_Toppings) && (otherTea.m_Foam == m_Foam) && (otherTea.m_Lidded == m_Lidded);
    }
    

    // TODO - GetHashCode? I don't think it'll be relevant

    public enum Liquid {
        None,
        GreenTea,
        BlackTea,
        Strawberry,
        Matcha,
        Water
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
        None
    }

    public enum Foam {
        None
    }
}
