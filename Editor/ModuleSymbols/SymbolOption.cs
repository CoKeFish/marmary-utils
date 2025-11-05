#if UNITY_EDITOR

using System;

namespace MyCompany.ModuleSymbols

{

    [Serializable]

    public class SymbolOption

    {

        public string symbol;

        public string description;

        public bool enabledByDefault;

    }

}

#endif


