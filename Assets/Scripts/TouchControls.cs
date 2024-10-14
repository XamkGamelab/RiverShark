//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/TouchControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class TouchControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public TouchControls()
    {
        asset = InputActionAsset.FromJson(@"{
            ""name"": ""TouchControls"",
            ""maps"": [
                {
                    ""name"": ""Touch"",
                    ""id"": ""7265d4c4-606a-49d8-a9be-197332e7cd3f"",
                    ""actions"": [
                        {
                            ""name"": ""PrimaryContact"",
                            ""type"": ""PassThrough"",
                            ""id"": ""10292165-7c0f-4314-8f87-83362688ec3f"",
                            ""expectedControlType"": ""Button"",
                            ""processors"": """",
                            ""interactions"": """",
                            ""initialStateCheck"": true
                        },
                        {
                            ""name"": ""PrimaryPosition"",
                            ""type"": ""PassThrough"",
                            ""id"": ""271d5c8a-2232-44ef-bb29-933d96f49d79"",
                            ""expectedControlType"": ""Vector2"",
                            ""processors"": """",
                            ""interactions"": """",
                            ""initialStateCheck"": false
                        }
                    ],
                    ""bindings"": [
                        {
                            ""name"": """",
                            ""id"": ""2fb8ad71-8b3c-4352-8ee3-dbb32539b090"",
                            ""path"": ""<Touchscreen>/primaryTouch/press"",
                            ""interactions"": ""Tap"",
                            ""processors"": """",
                            ""groups"": """",
                            ""action"": ""PrimaryContact"",
                            ""isComposite"": false,
                            ""isPartOfComposite"": false
                        },
                        {
                            ""name"": """",
                            ""id"": ""09100ac0-be0c-469a-8c3b-d7adbdeef61d"",
                            ""path"": ""<Touchscreen>/primaryTouch/position"",
                            ""interactions"": """",
                            ""processors"": """",
                            ""groups"": """",
                            ""action"": ""PrimaryPosition"",
                            ""isComposite"": false,
                            ""isPartOfComposite"": false
                        }
                    ]
                }
            ],
            ""controlSchemes"": []
        }");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_PrimaryContact = m_Touch.FindAction("PrimaryContact", throwIfNotFound: true);
        m_Touch_PrimaryPosition = m_Touch.FindAction("PrimaryPosition", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return FindBinding(bindingMask, out action);
    }

    // Touch
    private readonly InputActionMap m_Touch;
    private readonly InputAction m_Touch_PrimaryContact;
    private readonly InputAction m_Touch_PrimaryPosition;

    public struct TouchActions
    {
        private TouchControls m_Wrapper;
        public TouchActions(TouchControls wrapper) { m_Wrapper = wrapper; }
        public InputAction PrimaryContact => m_Wrapper.m_Touch_PrimaryContact;
        public InputAction PrimaryPosition => m_Wrapper.m_Touch_PrimaryPosition;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
    }

    public TouchActions Touch => new TouchActions(this);
}