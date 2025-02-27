﻿using System;

namespace EVESharp.Database.Exceptions;

public class ItemNotLoadedException : Exception
{
    public ItemNotLoadedException (int itemID, string extraInfo = "") : base ($"The given item ({itemID}) is not loaded by this ItemManager: {extraInfo}") { }
}