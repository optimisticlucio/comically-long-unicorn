using UnityEngine;

public class BobaTea
{
    Liquid m_Liquid = Liquid.None;
    Tapioca m_Tapioca = Tapioca.None;
    Topping m_Topping = Topping.None;
    Foam m_Foam = Foam.None;

    public BobaTea(Liquid liquid, Tapioca tapioca, Topping topping, Foam foam) {
        m_Liquid = liquid;
        m_Tapioca = tapioca;
        m_Topping = topping;
        m_Foam = foam;
    }

    enum Liquid {
        None,
        Tea,
        Water
    }

    enum Tapioca {
        None,
        Bubbles
    }

    enum Topping {
        None
    }

    enum Foam {
        None
    }
}
