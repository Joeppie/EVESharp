using System;
using EVESharp.EVE.Sessions;
using EVESharp.Types;

namespace EVESharp.EVE.Network.Services.Validators;

[AttributeUsage (AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
public class MustNotBeCharacter : CallValidator
{
    public override bool Validate (Session session)
    {
        return session.TryGetValue (Session.CHAR_ID, out PyDataType value) == false || value is null;
    }
}