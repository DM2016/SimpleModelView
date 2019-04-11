﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

/// <summary>
/// An SVMview for an InputField element used for float values.
/// </summary>
public class SMVViewInputFieldFloat : SMVviewBase
{
    public override void Init(SMVstate parent)
    {
        //Find the UI element within this components game object
        UIelement = transform.GetComponent<InputField>();
        if (UIelement == null)
            Debug.LogError("uiElement == null");

        //Add the change-listener from base class
        //Always use the EndEdit event so we don't end up with validation errors while typing
        (((InputField)UIelement).onEndEdit).AddListener(delegate { OnValueChangedListener(); });

        smvtype = SMVtypeEnum.inputFieldFloat;
        dataType = typeof(float);
        this.parent = parent;
    }

    public override object GetValueAsObject()
    {
        //Just return the string object, and validation method will handle the parsing
        return ((InputField)UIelement).text;
    }

    protected override void SetValueInternal(object val)
    {
        ((InputField)UIelement).text = val.ToString();
    }
}