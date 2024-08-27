using UnityEngine;


namespace Eloi
{

    public static partial class BoolEvent {


        public static partial class Bean {
            [System.Serializable]
            public class ObservedBooleanValueChange
            {

                [SerializeField] bool m_booleanState;
                public void SetBoolean(in bool value, out bool changed)
                {
                    changed = value != m_booleanState;
                    m_booleanState = value;
                }
                public void GetBoolean(out bool value) => value = m_booleanState;
                public bool GetBoolean()
                {
                    return m_booleanState;
                }
            }


            


        }
    }



}