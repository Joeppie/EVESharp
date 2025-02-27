﻿using EVESharp.Types.Collections;

namespace EVESharp.EVE.Exceptions.LSC;

public class ChtCharNotReachable : UserError
{
    public ChtCharNotReachable (int characterID) : base ("ChtCharNotReachable", new PyDictionary {["char"] = FormatOwnerID (characterID)}) { }
}