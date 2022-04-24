// GENERATED AUTOMATICALLY FROM 'Assets/Input/Master.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @CMInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @CMInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Master"",
    ""maps"": [
        {
            ""name"": ""Camera"",
            ""id"": ""0916e8f4-adac-4f93-886e-7f72514589d5"",
            ""actions"": [
                {
                    ""name"": ""Hold to Move Camera"",
                    ""type"": ""Button"",
                    ""id"": ""37c4e574-0aea-4a6a-a4f2-575104bfd259"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b690809d-6128-4967-aa54-ad3b44b03278"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""+Rotate Camera"",
                    ""type"": ""Value"",
                    ""id"": ""2accd882-d6d0-439c-a1ed-189931751453"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Elevate Camera"",
                    ""type"": ""Button"",
                    ""id"": ""3fbaee37-d68e-4db9-8b0a-93d06160b118"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Toggle Fullscreen"",
                    ""type"": ""Button"",
                    ""id"": ""15237594-4027-4cbc-92ed-cad40331f90e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Location 1"",
                    ""type"": ""Button"",
                    ""id"": ""6eff2680-b351-48d1-ade1-024ef991d7bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Location 2"",
                    ""type"": ""Button"",
                    ""id"": ""31fc282b-3de2-4eec-bf02-2fbeb5927c39"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Location 3"",
                    ""type"": ""Button"",
                    ""id"": ""4420a6bd-184a-4ad4-ba40-f16ed673a74f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Location 4"",
                    ""type"": ""Button"",
                    ""id"": ""9bed9d33-1ae7-4eb2-bda6-00e8d932c487"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Second Set Modifier"",
                    ""type"": ""Button"",
                    ""id"": ""7a88eefa-a24b-474d-bf6e-94546642f826"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Overwrite Location Modifier"",
                    ""type"": ""Button"",
                    ""id"": ""d07f611a-4dad-4460-90c3-bed5e359444b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Movement"",
                    ""id"": ""1f652d44-378c-4d9e-8c08-62c19d5c94f1"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move Camera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d2d63e78-e4cd-4476-9bb7-95f6a64724ec"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Move Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b8fce530-a706-4d90-ac3c-ef71b30fbd25"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Move Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""67d23d5e-4301-4614-9bdb-a74d720b28ca"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Move Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""91ac3309-f9db-4830-82c5-449f7edaf79f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Move Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7da07213-d4f5-4c66-9fd0-b6b34595b8fa"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""+Rotate Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""17ca5bb4-7047-4825-82c9-07dae2c23736"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Elevate Camera"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""066474db-11dd-4e08-9aa5-234b05ba63e7"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Elevate Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5b427547-d298-4bdc-9aad-aa05d2e3fbf5"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Elevate Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""036bf932-8107-4b8f-8851-2333b0cace51"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Hold to Move Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e90cd3d-5414-4527-96b2-7c362f3cd07e"",
                    ""path"": ""<Keyboard>/f11"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Toggle Fullscreen"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81f3b05f-dcf0-44fa-a7b4-884e8d1f6dea"",
                    ""path"": ""<Keyboard>/f5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Location 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5020cf0d-1c99-4243-8959-0a001366eb4c"",
                    ""path"": ""<Keyboard>/f6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Location 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""085ccf2b-b5c8-4933-8d7d-f355ae797fff"",
                    ""path"": ""<Keyboard>/f7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Location 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""636ad657-e61f-44ca-974c-c088b78582a4"",
                    ""path"": ""<Keyboard>/f8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Location 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d5b5bc0-ba34-4f29-a577-b221c6fb3e3c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Second Set Modifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b920061-f2e4-4f27-8854-cc74b3ad2567"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Overwrite Location Modifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""+Utils"",
            ""id"": ""f4c0c3c1-a81f-4d2c-8b60-075660df638d"",
            ""actions"": [
                {
                    ""name"": ""Control Modifier"",
                    ""type"": ""Button"",
                    ""id"": ""a5c857c0-7636-4e1c-8510-22f4e72d2b01"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Alt Modifier"",
                    ""type"": ""Button"",
                    ""id"": ""e5b2efee-cf71-4d04-ba3a-c544cc5b2be2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shift Modifier"",
                    ""type"": ""Button"",
                    ""id"": ""80d43d78-82d6-4589-8fd9-89580f03b9c4"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""965f30e2-f75b-4a64-a00c-e21258ef8eb3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f23fa707-1a17-4b14-84ad-c47826b4f3f5"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Control Modifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6de791ad-e805-48fb-9996-766bc48ed508"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Control Modifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""391d2675-e019-4314-96fb-6681421f4e8c"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Control Modifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5d1cf75-5eee-4cd8-a505-0751117cee28"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Alt Modifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b25fb98-6eb3-4ff9-aed4-120bf37c130e"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Shift Modifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f18d965b-6bfa-4a42-8abb-5c01ee7d15dc"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Mouse Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Actions"",
            ""id"": ""3e26cae6-c1ff-441d-96fc-9f7505133eed"",
            ""actions"": [
                {
                    ""name"": ""Undo (Method 1)"",
                    ""type"": ""Button"",
                    ""id"": ""fedad900-9c47-459d-bddd-f46d2be3e180"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Undo (Method 2)"",
                    ""type"": ""Button"",
                    ""id"": ""c62387e5-adc8-4366-b018-e897233be233"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Redo (Method 1)"",
                    ""type"": ""Button"",
                    ""id"": ""7d4b7471-e9f7-4b02-86f8-93f38fad7792"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Redo (Method 2)"",
                    ""type"": ""Button"",
                    ""id"": ""06f077ed-f9cc-43ae-87f3-7be30bd3ff5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Method 1"",
                    ""id"": ""63fba69a-8406-46a8-ab67-b0dcb07b0e85"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Undo (Method 1)"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""3e22674a-5051-463b-bcba-5a248fa9a5fa"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Undo (Method 1)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""06c530a9-a274-47b8-ac73-f9ed8563d580"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Undo (Method 1)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Method 1"",
                    ""id"": ""a52c3108-e4d8-4b89-9ee2-4a4c4667b94b"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Redo (Method 1)"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""9aa308dc-6d77-4fc9-a3e2-4bc7d435d5df"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Redo (Method 1)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""9da5084e-053a-4f50-9426-ad006cf4a589"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Redo (Method 1)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Method 2"",
                    ""id"": ""8d2a0118-7d90-404b-bc4b-7e75c6c16e77"",
                    ""path"": ""ButtonWithTwoModifiers"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Undo (Method 2)"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier1"",
                    ""id"": ""c820fc98-a631-4ba2-8872-cd9483499893"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Undo (Method 2)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier2"",
                    ""id"": ""5a28b45b-80a4-42a5-83e5-ac4f005fa771"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Undo (Method 2)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""c1ddbbb8-0a6d-4c3a-8669-a50557a09c5c"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Undo (Method 2)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Method 2"",
                    ""id"": ""be16ab06-06ea-4ff7-b65a-6992a3b7f241"",
                    ""path"": ""ButtonWithTwoModifiers"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Redo (Method 2)"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier1"",
                    ""id"": ""8a3596a9-27e1-400e-ace9-b86b372e4bf0"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Redo (Method 2)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier2"",
                    ""id"": ""a1c11c18-f1aa-4aed-9001-fdc2fe444b63"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Redo (Method 2)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""bc950e09-863a-4000-8e9b-d378889d7124"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Redo (Method 2)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Placement Controllers"",
            ""id"": ""ad57992b-d8ff-4c39-a762-db68cf7d04db"",
            ""actions"": [
                {
                    ""name"": ""Place Object"",
                    ""type"": ""Button"",
                    ""id"": ""12ac2167-b8c0-4f4f-aa6e-17a1aacc42ca"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Initiate Click and Drag"",
                    ""type"": ""Button"",
                    ""id"": ""15cbdd9a-b2fe-489a-b70c-81e0261ba8b8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Initiate Click and Drag at Time"",
                    ""type"": ""Button"",
                    ""id"": ""fbb3f339-0978-4e67-ad3c-e7410c4c6eae"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""+Mouse Position Update"",
                    ""type"": ""Button"",
                    ""id"": ""3c3cb17e-12c8-41c6-b727-8f8f86c0f325"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel Placement"",
                    ""type"": ""Button"",
                    ""id"": ""46847cde-27d4-4053-97f9-16d618e5e779"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""21742f4d-6389-49c4-85b0-4446e428b468"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Initiate Click and Drag"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""955b0c04-2b09-4a08-a154-6c5b86083f1a"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Initiate Click and Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""0f79b592-c40a-47fc-9b0d-9d5244fbd4a0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Initiate Click and Drag"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5972be07-cf3b-44d3-861b-c80e8d655778"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Place Object"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca96ac27-5948-4b00-83e4-0acba376a448"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""+Mouse Position Update"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""f771a3f4-66e6-4697-8664-a235d56bf974"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Initiate Click and Drag at Time"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""fedfd0fc-5adf-46c1-a55f-d32105f5ff62"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Initiate Click and Drag at Time"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""d356459a-e712-4d22-be53-565bc0eb56a7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Initiate Click and Drag at Time"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""cf4e59e4-9cd9-4f60-8f21-43ba4c0a1ef0"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Cancel Placement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Workflows"",
            ""id"": ""62377dd3-26a7-4161-ab65-7a5042f0dfc0"",
            ""actions"": [
                {
                    ""name"": ""Toggle Note Color"",
                    ""type"": ""Button"",
                    ""id"": ""1ef71b14-df3b-4fc2-bdf9-602b8848435b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Place Red Note"",
                    ""type"": ""Button"",
                    ""id"": ""7c3ce073-947a-41d5-900e-0afddf733685"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Place Blue Note"",
                    ""type"": ""Button"",
                    ""id"": ""15a1d710-c76f-42b5-81fd-53dc8bde4712"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Toggle Delete Tool"",
                    ""type"": ""Button"",
                    ""id"": ""093f99e8-5a4f-4d76-aa7d-cce4ecfe95f1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Mirror Horizontally"",
                    ""type"": ""Button"",
                    ""id"": ""4b2fa447-5ce7-4170-b3db-e1998f0c5bf3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Mirror Vertically"",
                    ""type"": ""Button"",
                    ""id"": ""498f60ef-e707-40fb-b5d5-8b8f20fa37e4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Mirror in Time"",
                    ""type"": ""Button"",
                    ""id"": ""c00d60fa-c8b5-4bde-b5ef-e7ac2e468d23"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Mirror Colours Only"",
                    ""type"": ""Button"",
                    ""id"": ""49a26cd7-a4f5-474b-b589-5836d7849685"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Swap Cursor Interval"",
                    ""type"": ""Button"",
                    ""id"": ""6d478ae5-4a83-4562-a182-ef304b55364b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""3554826a-1869-442a-9a69-1292f35c532f"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Place Red Note"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8996b934-950d-4fcf-9c11-35c09605e946"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Place Blue Note"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5dc2e98d-6185-400c-b701-95aad571a194"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Toggle Delete Tool"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d727af0f-0739-4466-b11b-8f33377f65ca"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Mirror Horizontally"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""d26158af-d8ee-4294-b2cd-9072faca037b"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mirror Colours Only"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0966afc2-7e2e-46d9-a484-b0f36bbe0c08"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mirror Colours Only"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""fd0da496-7629-40b4-a7d0-85959f333501"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mirror Colours Only"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4301dab3-322d-4618-b1b6-0229fa7ee467"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Toggle Note Color"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1373dc4f-0062-4d46-9f16-add8ab5f59b7"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Swap Cursor Interval"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With Two Modifiers"",
                    ""id"": ""3f754dba-427a-42e8-95f4-5bf9f47497e7"",
                    ""path"": ""ButtonWithTwoModifiers"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mirror in Time"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier1"",
                    ""id"": ""6e24801c-fd22-4ebd-8837-967b5189b37e"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Mirror in Time"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier2"",
                    ""id"": ""ed7f4706-bb5e-4a24-aa2e-f1c72a7f9c84"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Mirror in Time"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""eb64901a-7952-46e1-a983-cbc9220435c9"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Mirror in Time"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""e147ccfb-914d-4db7-b04c-99cae5794a1d"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mirror Vertically"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""8e11b2dc-744d-46ad-ae4a-e4a935f33f77"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Mirror Vertically"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""f6824464-7e6c-4f89-bcb8-d114ccb5aace"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Mirror Vertically"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Saving"",
            ""id"": ""a07ff948-83f1-461b-988e-d6c1d9e6aadc"",
            ""actions"": [
                {
                    ""name"": ""Save"",
                    ""type"": ""Button"",
                    ""id"": ""2ee88999-e5b4-4f09-a327-2ef63121ca4b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""6328c205-5a07-458b-8173-a7c982608950"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Save"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""9ffd022a-7d16-492a-9f73-ddbbcd2c484d"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""e072a367-7f62-4b49-9f0f-f39474fabfb8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Save"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Bookmarks"",
            ""id"": ""358e632a-614c-4580-adb7-64e863720b71"",
            ""actions"": [
                {
                    ""name"": ""Create New Bookmark"",
                    ""type"": ""Button"",
                    ""id"": ""5bd99bac-a957-4d98-b68e-e74a153090fe"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Next Bookmark"",
                    ""type"": ""Button"",
                    ""id"": ""9cf9a467-5b4f-4564-af39-2d2dc34ae6c8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Previous Bookmark"",
                    ""type"": ""Button"",
                    ""id"": ""a52b1ae8-89b5-4136-a550-f09b65a78fe8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Color Bookmark Modifier"",
                    ""type"": ""Button"",
                    ""id"": ""4439bbde-d3c0-49f8-9005-d710ca8202b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5c946efd-12d6-4d24-a7d5-e85bc9925ef2"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Create New Bookmark"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c626b60b-2b5d-4d04-a749-55aebb76584a"",
                    ""path"": ""<Keyboard>/rightBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Next Bookmark"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""471da8dd-be12-4744-b508-edafcabf5e35"",
                    ""path"": ""<Keyboard>/leftBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Previous Bookmark"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eaa182da-bc19-4c48-b13e-af966ffe9485"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Color Bookmark Modifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Refresh Map"",
            ""id"": ""0d506325-9cd5-4fc8-a448-4b7c30acc9fa"",
            ""actions"": [
                {
                    ""name"": ""Refresh Map"",
                    ""type"": ""Button"",
                    ""id"": ""3ae94594-1532-421a-b6c2-1e1f4cded029"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""38aa9fd6-7b8e-456e-88f6-4d0f56a66d44"",
                    ""path"": ""ButtonWithTwoModifiers"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Refresh Map"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier1"",
                    ""id"": ""104a0fc2-15da-480f-b5bc-d5c3a84f6dd1"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Refresh Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier2"",
                    ""id"": ""c2bb7644-ac4e-41fb-8943-e6666c9fe94d"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Refresh Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""41064415-c0bb-4961-b49f-4e4c38342c16"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Refresh Map"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Playback"",
            ""id"": ""0d5d9c0b-70f8-4457-a4dc-6d4a43631147"",
            ""actions"": [
                {
                    ""name"": ""Toggle Playing"",
                    ""type"": ""Button"",
                    ""id"": ""84057134-9c36-4d2f-bcc5-ba76c04e98fa"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Reset Time"",
                    ""type"": ""Button"",
                    ""id"": ""996859cc-5dc0-4ef5-9e53-27c5a45f9e7d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""12f09c2c-d135-4283-b28f-59694bbdaaab"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Toggle Playing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59ab5455-dd74-429f-808f-1c09186ae5de"",
                    ""path"": ""<Keyboard>/semicolon"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Reset Time"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Timeline"",
            ""id"": ""a71da820-2d7a-44ff-b989-f6bc4b2a172b"",
            ""actions"": [
                {
                    ""name"": ""+Change Time and Precision"",
                    ""type"": ""Button"",
                    ""id"": ""e046fbab-3ebb-4a53-8594-08a0ae193ab6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Change Precision Modifier"",
                    ""type"": ""Button"",
                    ""id"": ""77c42d52-fde6-407d-baa5-a18d9ce1a755"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Precise Snap Modification"",
                    ""type"": ""Button"",
                    ""id"": ""6710a953-988b-430d-94ad-561bcd9b5c2a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b84aada6-3206-469c-876e-43da8d5cc266"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""+Change Time and Precision"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93928bfb-c637-475e-a029-b96ccfdacd36"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Precise Snap Modification"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37dfc13c-313e-467d-9a85-bf32c835a7d0"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Change Precision Modifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Editor Scale"",
            ""id"": ""0e43e367-0347-44b6-821c-d27e4a771f4d"",
            ""actions"": [
                {
                    ""name"": ""Decrease Editor Scale"",
                    ""type"": ""Button"",
                    ""id"": ""843d7818-4304-4540-94d4-1e1693a9eea5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Increase Editor Scale"",
                    ""type"": ""Button"",
                    ""id"": ""fd88cf86-8a74-4ccf-871c-784f047ee448"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""e9554239-5972-46a1-8422-d8490129c51e"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Decrease Editor Scale"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""055e14ec-6692-4508-87f5-9ba1bb12abc7"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Decrease Editor Scale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""633af040-8add-4484-bdf5-280ddef99e61"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Decrease Editor Scale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""dea1193c-74e3-48ad-9a93-e06f71602b02"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Increase Editor Scale"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""70bf59b6-875b-46c8-8f14-138099098d3f"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Increase Editor Scale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""73d533ab-b1e0-4c2b-a97d-a12ccded1261"",
                    ""path"": ""<Keyboard>/equals"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Increase Editor Scale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Beatmap Objects"",
            ""id"": ""b5cba2db-88ec-4e5b-9b0a-095ae70a1a75"",
            ""actions"": [
                {
                    ""name"": ""Select Objects"",
                    ""type"": ""Button"",
                    ""id"": ""99ccd235-d96f-4545-b9da-116c171bb16b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Mass Select Modifier"",
                    ""type"": ""Button"",
                    ""id"": ""3266236c-fda3-4697-bd0e-2a659c9cb072"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quick Delete"",
                    ""type"": ""Button"",
                    ""id"": ""f1e5f862-455a-4d77-bc08-92e2c7849e0d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Delete Tool"",
                    ""type"": ""Button"",
                    ""id"": ""0b907b9a-c55c-4ff8-a752-aba188528875"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""+Mouse Position Update"",
                    ""type"": ""Button"",
                    ""id"": ""0ad31924-f097-4801-a571-a40b54af42e6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump to Object Time"",
                    ""type"": ""Button"",
                    ""id"": ""ed95bf18-89cf-4c3c-8bb5-c4464ccaff0f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""b19df616-95f6-4715-b98a-1d18373d95ca"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select Objects"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""e4a67a51-9079-460b-a6c9-9103896219d8"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Select Objects"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""962af3e5-c6b2-40d0-8e6b-7a7c0e57ac2f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Select Objects"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""25dfcc81-8a03-4484-b81d-29f0a85c3ece"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quick Delete"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""a029bb83-1266-415b-b150-0ecc2c4d96de"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Quick Delete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""7468f859-883c-46a0-b612-9e15eeb0fecd"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Quick Delete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f872bf2a-d2da-47b0-a049-362822fbf94a"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Delete Tool"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6cc9107d-1265-4184-ace8-b8fa13cb35a8"",
                    ""path"": ""<Pointer>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""+Mouse Position Update"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""0e677247-32a0-49f6-8d2f-05530effc437"",
                    ""path"": ""ButtonWithTwoModifiers"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump to Object Time"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier1"",
                    ""id"": ""06371070-16b9-4eeb-b50d-1b406bc6625b"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump to Object Time"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier2"",
                    ""id"": ""b4e864ab-54e6-4257-9918-e78691252233"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump to Object Time"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""560354a5-1a3e-4c31-92e3-10df016ad2f2"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump to Object Time"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7a3763f3-e3a9-400d-b578-9bbf4142d1e4"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Mass Select Modifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Note Objects"",
            ""id"": ""d18a448a-b849-4a22-a103-3a79418bc61b"",
            ""actions"": [
                {
                    ""name"": ""Invert Note Colors"",
                    ""type"": ""Button"",
                    ""id"": ""5bf4f065-0e9f-4166-a219-7ec603ae88c6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Quick Direction Modifier"",
                    ""type"": ""Button"",
                    ""id"": ""1b6c3334-9477-4c00-8cdd-b205854dcc67"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a1a9d032-f76b-4e85-8d27-46380767f735"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Invert Note Colors"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e7061369-7f91-42ba-9804-7e80aeac60ff"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Quick Direction Modifier"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""BPM Change Objects"",
            ""id"": ""dcc47838-c346-486c-8c4c-6a3074023cb3"",
            ""actions"": [
                {
                    ""name"": ""Replace BPM"",
                    ""type"": ""Button"",
                    ""id"": ""9f9b573b-d4b1-439c-b3f9-17336ada4933"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tweak BPM Value"",
                    ""type"": ""Button"",
                    ""id"": ""d5500879-426b-4d21-b2e8-b9e11de4c331"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""21a62bbe-f4ce-419f-ae19-14d29edb1362"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Replace BPM"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""bd0c2548-257d-4551-8c64-dd5f86c44543"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Replace BPM"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""414dede3-0ceb-4e97-b164-772b756aeebd"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Replace BPM"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""b9437e71-7074-402d-9abe-9f1ef4071e15"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tweak BPM Value"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""64333cae-86d5-436c-a120-2657519d7464"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Tweak BPM Value"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""02a89018-2048-45e5-bcf2-61356550f061"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Tweak BPM Value"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Box Select"",
            ""id"": ""ce387cfe-7aed-46ef-ab8b-e0cf196f6a96"",
            ""actions"": [
                {
                    ""name"": ""Activate Box Select"",
                    ""type"": ""Button"",
                    ""id"": ""1bfcb620-0275-4b3e-a89d-2e5d52203c8d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f6185091-72dd-4efb-ab34-6ea3096834c6"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Activate Box Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""BPM Tapper"",
            ""id"": ""2badd83b-e1b2-41b0-abb2-cb8a4b79e7da"",
            ""actions"": [
                {
                    ""name"": ""Toggle BPM Tapper"",
                    ""type"": ""Button"",
                    ""id"": ""c9a9c9a6-a5d3-488f-b54a-aba65b60d56a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e9fa4476-2c7f-4dee-bbeb-a02ad348c6dd"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Toggle BPM Tapper"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Pause Menu"",
            ""id"": ""3b859155-292c-4d12-8778-4e0133970c44"",
            ""actions"": [
                {
                    ""name"": ""Pause Editor"",
                    ""type"": ""Button"",
                    ""id"": ""fa86a48b-260e-44cc-9436-e4155eaeb871"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b8d726be-7155-47b3-8ae1-649f26f670c9"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Pause Editor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Selection"",
            ""id"": ""b3792a28-92fa-4821-90b9-504529c52fd1"",
            ""actions"": [
                {
                    ""name"": ""Deselect All"",
                    ""type"": ""Button"",
                    ""id"": ""f592a091-9740-4e72-8f17-4d26ccf2698a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Delete Objects"",
                    ""type"": ""Button"",
                    ""id"": ""9b6770ad-b031-4ab2-86fe-c85f0b55501f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Cut"",
                    ""type"": ""Button"",
                    ""id"": ""e9677e31-a29a-40d9-9831-3b0bf425e410"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Paste"",
                    ""type"": ""Button"",
                    ""id"": ""1dc463d8-b058-4507-92da-42817903ce61"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Copy"",
                    ""type"": ""Button"",
                    ""id"": ""ba0f5eb7-64f2-46b8-afd4-219d6a5b9321"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Overwrite Paste"",
                    ""type"": ""Button"",
                    ""id"": ""17cb35a5-a1b3-4c1f-a450-ceb25a448d18"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Rotate Selection"",
                    ""type"": ""Button"",
                    ""id"": ""8c73d497-930e-4e62-a3d1-754783ee7711"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Shift Selection Forward"",
                    ""type"": ""Button"",
                    ""id"": ""3c016fdf-f227-498d-ad14-217c46c0324d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Shift Selection Backward"",
                    ""type"": ""Button"",
                    ""id"": ""11b9a468-39ee-4327-8ff5-426a8497c47b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ea2c9e32-8af1-4937-a4ae-db24fb9a3682"",
                    ""path"": ""<Keyboard>/delete"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Delete Objects"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""52d4022b-41e9-4bb7-b451-fea39d569968"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cut"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""7c14d3c7-c2b2-4954-b831-dca8f7b4169c"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Cut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""eb15991c-e91e-4f22-aea7-6f15a1ffb5cd"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Cut"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""5ee8b28e-cf8e-4dc7-80a6-bff077609d02"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Copy"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""e8429e9a-ee74-4307-9759-54b5099dd3f3"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Copy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""3830cfe9-2fdf-4f8b-8b15-93e18b392e4d"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Copy"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""b5a7a345-5a41-4e0a-9527-2ca046a0e361"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Paste"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0dd280bb-bcfa-44c8-ab93-f496061b6bbe"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Paste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""de4aafba-900a-42c4-8543-783acedf0997"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Paste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2e15fffc-29fe-4cb1-b601-e7a67cea0f96"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Delete Objects"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""93c4668a-e8a6-470a-86e4-7dc07939d1ca"",
                    ""path"": ""ButtonWithTwoModifiers"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Overwrite Paste"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier1"",
                    ""id"": ""bbc0d7ac-92d8-4532-a7ea-c8a98ac9ab3f"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Overwrite Paste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""modifier2"",
                    ""id"": ""8e309fc0-65b8-4871-ac4c-4a7abdf9b864"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Overwrite Paste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""c4e04efa-cef2-47ac-a794-a622a9eab834"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Overwrite Paste"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""79c5c421-e970-43e6-953e-444eb99927b1"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Deselect All"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""5c1aa968-84dd-4c65-bc43-0d48e8bc1d67"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Deselect All"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""2d1bb3a4-abb8-4b08-ad50-25849b624648"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Deselect All"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""09f4b6c6-54a8-4e6c-bfa9-30506bd50a20"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""17ce93ef-9538-43e3-9c2f-036f52bc40cd"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Rotate Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""140990cf-8d5b-482d-a5d0-72294b21a142"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Rotate Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""e8afd1e7-bd4d-4c5a-94cf-06ef54d74fbc"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift Selection Forward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""b0500e4d-4e2a-4a4f-a00f-dcc5642652f4"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Shift Selection Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""ab220a66-8d00-4fef-98ce-837744bdf718"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Shift Selection Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""fd933e86-1ff1-4cca-ac78-9952ba2c8aaa"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shift Selection Backward"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0606f668-0f66-44b0-94b1-7edca747872b"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Shift Selection Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""21798adb-05df-46ce-9ba3-3199ad766832"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Shift Selection Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""UI Mode"",
            ""id"": ""e3f966df-bf7d-4718-9605-fbaba1af857b"",
            ""actions"": [
                {
                    ""name"": ""Toggle UI Mode"",
                    ""type"": ""Button"",
                    ""id"": ""d49f10e6-ab3d-4821-b386-3083cb9ef3d1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""c9097b75-658f-4331-a6c1-1889024eb62c"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Toggle UI Mode"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""4d06a4a4-c18e-4e66-8ab1-a21bcead640d"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Toggle UI Mode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""aa694fd9-9a8b-47b8-a9ac-682e08347b75"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Toggle UI Mode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Song Speed"",
            ""id"": ""8190159d-1cd6-4a3b-a047-0a6b3f7e9b38"",
            ""actions"": [
                {
                    ""name"": ""Decrease Song Speed"",
                    ""type"": ""Button"",
                    ""id"": ""1810e054-2601-41ff-96dc-d7d407c30f99"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Increase Song Speed"",
                    ""type"": ""Button"",
                    ""id"": ""27b6f64a-429b-4433-97e3-135d5092ace9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8c2f4104-14e0-4a31-b6c6-ae076b925d59"",
                    ""path"": ""<Keyboard>/equals"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Increase Song Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2f59880-adb4-49c7-b200-e3edc208ec75"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Decrease Song Speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenusExtended"",
            ""id"": ""0a34d3d3-4820-4928-bf89-0c72500b3025"",
            ""actions"": [
                {
                    ""name"": ""Tab"",
                    ""type"": ""Button"",
                    ""id"": ""4468e9ca-6edd-4a3f-a163-91afa51f77c8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Leave Menu"",
                    ""type"": ""Button"",
                    ""id"": ""ad0f8cea-e5cf-486e-bb47-dac40c46f9bc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""03c8a6ee-0c97-4c95-87cb-9c7a070e6a81"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Tab"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""040fc1e4-92db-4011-8025-6ad6704238df"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Leave Menu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""7fe5c72f-64fa-4eea-854c-6ca63f927fb1"",
            ""actions"": [
                {
                    ""name"": ""Toggle Debug Console"",
                    ""type"": ""Button"",
                    ""id"": ""ffa7e0a4-2351-457e-916c-c219fe7f7698"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""83d2a9f1-1b9d-41f6-9a1f-b7d17e53934f"",
                    ""path"": ""<Keyboard>/backquote"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Toggle Debug Console"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Audio"",
            ""id"": ""d4995a94-4c43-40b2-9c2e-6c14380de6bb"",
            ""actions"": [
                {
                    ""name"": ""Toggle Hitsound Mute"",
                    ""type"": ""Button"",
                    ""id"": ""330cfd81-242f-446b-b926-955336819490"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""5379c7dc-19a2-45cf-8469-7a496129e8f0"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Toggle Hitsound Mute"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""df4e1ba0-a7fb-4506-8bc0-6720e7112cff"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Toggle Hitsound Mute"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""e9f91017-683e-4745-ae30-d0e19544b0c4"",
                    ""path"": ""<Keyboard>/f1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""ChroMapper Default"",
                    ""action"": ""Toggle Hitsound Mute"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""ChroMapper Default"",
            ""bindingGroup"": ""ChroMapper Default"",
            ""devices"": []
        }
    ]
}");
        // Camera
        m_Camera = asset.FindActionMap("Camera", throwIfNotFound: true);
        m_Camera_HoldtoMoveCamera = m_Camera.FindAction("Hold to Move Camera", throwIfNotFound: true);
        m_Camera_MoveCamera = m_Camera.FindAction("Move Camera", throwIfNotFound: true);
        m_Camera_RotateCamera = m_Camera.FindAction("+Rotate Camera", throwIfNotFound: true);
        m_Camera_ElevateCamera = m_Camera.FindAction("Elevate Camera", throwIfNotFound: true);
        m_Camera_ToggleFullscreen = m_Camera.FindAction("Toggle Fullscreen", throwIfNotFound: true);
        m_Camera_Location1 = m_Camera.FindAction("Location 1", throwIfNotFound: true);
        m_Camera_Location2 = m_Camera.FindAction("Location 2", throwIfNotFound: true);
        m_Camera_Location3 = m_Camera.FindAction("Location 3", throwIfNotFound: true);
        m_Camera_Location4 = m_Camera.FindAction("Location 4", throwIfNotFound: true);
        m_Camera_SecondSetModifier = m_Camera.FindAction("Second Set Modifier", throwIfNotFound: true);
        m_Camera_OverwriteLocationModifier = m_Camera.FindAction("Overwrite Location Modifier", throwIfNotFound: true);
        // +Utils
        m_Utils = asset.FindActionMap("+Utils", throwIfNotFound: true);
        m_Utils_ControlModifier = m_Utils.FindAction("Control Modifier", throwIfNotFound: true);
        m_Utils_AltModifier = m_Utils.FindAction("Alt Modifier", throwIfNotFound: true);
        m_Utils_ShiftModifier = m_Utils.FindAction("Shift Modifier", throwIfNotFound: true);
        m_Utils_MouseMovement = m_Utils.FindAction("Mouse Movement", throwIfNotFound: true);
        // Actions
        m_Actions = asset.FindActionMap("Actions", throwIfNotFound: true);
        m_Actions_UndoMethod1 = m_Actions.FindAction("Undo (Method 1)", throwIfNotFound: true);
        m_Actions_UndoMethod2 = m_Actions.FindAction("Undo (Method 2)", throwIfNotFound: true);
        m_Actions_RedoMethod1 = m_Actions.FindAction("Redo (Method 1)", throwIfNotFound: true);
        m_Actions_RedoMethod2 = m_Actions.FindAction("Redo (Method 2)", throwIfNotFound: true);
        // Placement Controllers
        m_PlacementControllers = asset.FindActionMap("Placement Controllers", throwIfNotFound: true);
        m_PlacementControllers_PlaceObject = m_PlacementControllers.FindAction("Place Object", throwIfNotFound: true);
        m_PlacementControllers_InitiateClickandDrag = m_PlacementControllers.FindAction("Initiate Click and Drag", throwIfNotFound: true);
        m_PlacementControllers_InitiateClickandDragatTime = m_PlacementControllers.FindAction("Initiate Click and Drag at Time", throwIfNotFound: true);
        m_PlacementControllers_MousePositionUpdate = m_PlacementControllers.FindAction("+Mouse Position Update", throwIfNotFound: true);
        m_PlacementControllers_CancelPlacement = m_PlacementControllers.FindAction("Cancel Placement", throwIfNotFound: true);
        // Workflows
        m_Workflows = asset.FindActionMap("Workflows", throwIfNotFound: true);
        m_Workflows_ToggleNoteColor = m_Workflows.FindAction("Toggle Note Color", throwIfNotFound: true);
        m_Workflows_PlaceRedNote = m_Workflows.FindAction("Place Red Note", throwIfNotFound: true);
        m_Workflows_PlaceBlueNote = m_Workflows.FindAction("Place Blue Note", throwIfNotFound: true);
        m_Workflows_ToggleDeleteTool = m_Workflows.FindAction("Toggle Delete Tool", throwIfNotFound: true);
        m_Workflows_MirrorHorizontally = m_Workflows.FindAction("Mirror Horizontally", throwIfNotFound: true);
        m_Workflows_MirrorVertically = m_Workflows.FindAction("Mirror Vertically", throwIfNotFound: true);
        m_Workflows_MirrorinTime = m_Workflows.FindAction("Mirror in Time", throwIfNotFound: true);
        m_Workflows_MirrorColoursOnly = m_Workflows.FindAction("Mirror Colours Only", throwIfNotFound: true);
        m_Workflows_SwapCursorInterval = m_Workflows.FindAction("Swap Cursor Interval", throwIfNotFound: true);
        // Saving
        m_Saving = asset.FindActionMap("Saving", throwIfNotFound: true);
        m_Saving_Save = m_Saving.FindAction("Save", throwIfNotFound: true);
        // Bookmarks
        m_Bookmarks = asset.FindActionMap("Bookmarks", throwIfNotFound: true);
        m_Bookmarks_CreateNewBookmark = m_Bookmarks.FindAction("Create New Bookmark", throwIfNotFound: true);
        m_Bookmarks_NextBookmark = m_Bookmarks.FindAction("Next Bookmark", throwIfNotFound: true);
        m_Bookmarks_PreviousBookmark = m_Bookmarks.FindAction("Previous Bookmark", throwIfNotFound: true);
        m_Bookmarks_ColorBookmarkModifier = m_Bookmarks.FindAction("Color Bookmark Modifier", throwIfNotFound: true);
        // Refresh Map
        m_RefreshMap = asset.FindActionMap("Refresh Map", throwIfNotFound: true);
        m_RefreshMap_RefreshMap = m_RefreshMap.FindAction("Refresh Map", throwIfNotFound: true);
        // Playback
        m_Playback = asset.FindActionMap("Playback", throwIfNotFound: true);
        m_Playback_TogglePlaying = m_Playback.FindAction("Toggle Playing", throwIfNotFound: true);
        m_Playback_ResetTime = m_Playback.FindAction("Reset Time", throwIfNotFound: true);
        // Timeline
        m_Timeline = asset.FindActionMap("Timeline", throwIfNotFound: true);
        m_Timeline_ChangeTimeandPrecision = m_Timeline.FindAction("+Change Time and Precision", throwIfNotFound: true);
        m_Timeline_ChangePrecisionModifier = m_Timeline.FindAction("Change Precision Modifier", throwIfNotFound: true);
        m_Timeline_PreciseSnapModification = m_Timeline.FindAction("Precise Snap Modification", throwIfNotFound: true);
        // Editor Scale
        m_EditorScale = asset.FindActionMap("Editor Scale", throwIfNotFound: true);
        m_EditorScale_DecreaseEditorScale = m_EditorScale.FindAction("Decrease Editor Scale", throwIfNotFound: true);
        m_EditorScale_IncreaseEditorScale = m_EditorScale.FindAction("Increase Editor Scale", throwIfNotFound: true);
        // Beatmap Objects
        m_BeatmapObjects = asset.FindActionMap("Beatmap Objects", throwIfNotFound: true);
        m_BeatmapObjects_SelectObjects = m_BeatmapObjects.FindAction("Select Objects", throwIfNotFound: true);
        m_BeatmapObjects_MassSelectModifier = m_BeatmapObjects.FindAction("Mass Select Modifier", throwIfNotFound: true);
        m_BeatmapObjects_QuickDelete = m_BeatmapObjects.FindAction("Quick Delete", throwIfNotFound: true);
        m_BeatmapObjects_DeleteTool = m_BeatmapObjects.FindAction("Delete Tool", throwIfNotFound: true);
        m_BeatmapObjects_MousePositionUpdate = m_BeatmapObjects.FindAction("+Mouse Position Update", throwIfNotFound: true);
        m_BeatmapObjects_JumptoObjectTime = m_BeatmapObjects.FindAction("Jump to Object Time", throwIfNotFound: true);
        // Note Objects
        m_NoteObjects = asset.FindActionMap("Note Objects", throwIfNotFound: true);
        m_NoteObjects_InvertNoteColors = m_NoteObjects.FindAction("Invert Note Colors", throwIfNotFound: true);
        m_NoteObjects_QuickDirectionModifier = m_NoteObjects.FindAction("Quick Direction Modifier", throwIfNotFound: true);
        // BPM Change Objects
        m_BPMChangeObjects = asset.FindActionMap("BPM Change Objects", throwIfNotFound: true);
        m_BPMChangeObjects_ReplaceBPM = m_BPMChangeObjects.FindAction("Replace BPM", throwIfNotFound: true);
        m_BPMChangeObjects_TweakBPMValue = m_BPMChangeObjects.FindAction("Tweak BPM Value", throwIfNotFound: true);
        // Box Select
        m_BoxSelect = asset.FindActionMap("Box Select", throwIfNotFound: true);
        m_BoxSelect_ActivateBoxSelect = m_BoxSelect.FindAction("Activate Box Select", throwIfNotFound: true);
        // BPM Tapper
        m_BPMTapper = asset.FindActionMap("BPM Tapper", throwIfNotFound: true);
        m_BPMTapper_ToggleBPMTapper = m_BPMTapper.FindAction("Toggle BPM Tapper", throwIfNotFound: true);
        // Pause Menu
        m_PauseMenu = asset.FindActionMap("Pause Menu", throwIfNotFound: true);
        m_PauseMenu_PauseEditor = m_PauseMenu.FindAction("Pause Editor", throwIfNotFound: true);
        // Selection
        m_Selection = asset.FindActionMap("Selection", throwIfNotFound: true);
        m_Selection_DeselectAll = m_Selection.FindAction("Deselect All", throwIfNotFound: true);
        m_Selection_DeleteObjects = m_Selection.FindAction("Delete Objects", throwIfNotFound: true);
        m_Selection_Cut = m_Selection.FindAction("Cut", throwIfNotFound: true);
        m_Selection_Paste = m_Selection.FindAction("Paste", throwIfNotFound: true);
        m_Selection_Copy = m_Selection.FindAction("Copy", throwIfNotFound: true);
        m_Selection_OverwritePaste = m_Selection.FindAction("Overwrite Paste", throwIfNotFound: true);
        m_Selection_RotateSelection = m_Selection.FindAction("Rotate Selection", throwIfNotFound: true);
        m_Selection_ShiftSelectionForward = m_Selection.FindAction("Shift Selection Forward", throwIfNotFound: true);
        m_Selection_ShiftSelectionBackward = m_Selection.FindAction("Shift Selection Backward", throwIfNotFound: true);
        // UI Mode
        m_UIMode = asset.FindActionMap("UI Mode", throwIfNotFound: true);
        m_UIMode_ToggleUIMode = m_UIMode.FindAction("Toggle UI Mode", throwIfNotFound: true);
        // Song Speed
        m_SongSpeed = asset.FindActionMap("Song Speed", throwIfNotFound: true);
        m_SongSpeed_DecreaseSongSpeed = m_SongSpeed.FindAction("Decrease Song Speed", throwIfNotFound: true);
        m_SongSpeed_IncreaseSongSpeed = m_SongSpeed.FindAction("Increase Song Speed", throwIfNotFound: true);
        // MenusExtended
        m_MenusExtended = asset.FindActionMap("MenusExtended", throwIfNotFound: true);
        m_MenusExtended_Tab = m_MenusExtended.FindAction("Tab", throwIfNotFound: true);
        m_MenusExtended_LeaveMenu = m_MenusExtended.FindAction("Leave Menu", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_ToggleDebugConsole = m_Debug.FindAction("Toggle Debug Console", throwIfNotFound: true);
        // Audio
        m_Audio = asset.FindActionMap("Audio", throwIfNotFound: true);
        m_Audio_ToggleHitsoundMute = m_Audio.FindAction("Toggle Hitsound Mute", throwIfNotFound: true);
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

    // Camera
    private readonly InputActionMap m_Camera;
    private ICameraActions m_CameraActionsCallbackInterface;
    private readonly InputAction m_Camera_HoldtoMoveCamera;
    private readonly InputAction m_Camera_MoveCamera;
    private readonly InputAction m_Camera_RotateCamera;
    private readonly InputAction m_Camera_ElevateCamera;
    private readonly InputAction m_Camera_ToggleFullscreen;
    private readonly InputAction m_Camera_Location1;
    private readonly InputAction m_Camera_Location2;
    private readonly InputAction m_Camera_Location3;
    private readonly InputAction m_Camera_Location4;
    private readonly InputAction m_Camera_SecondSetModifier;
    private readonly InputAction m_Camera_OverwriteLocationModifier;
    public struct CameraActions
    {
        private @CMInput m_Wrapper;
        public CameraActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @HoldtoMoveCamera => m_Wrapper.m_Camera_HoldtoMoveCamera;
        public InputAction @MoveCamera => m_Wrapper.m_Camera_MoveCamera;
        public InputAction @RotateCamera => m_Wrapper.m_Camera_RotateCamera;
        public InputAction @ElevateCamera => m_Wrapper.m_Camera_ElevateCamera;
        public InputAction @ToggleFullscreen => m_Wrapper.m_Camera_ToggleFullscreen;
        public InputAction @Location1 => m_Wrapper.m_Camera_Location1;
        public InputAction @Location2 => m_Wrapper.m_Camera_Location2;
        public InputAction @Location3 => m_Wrapper.m_Camera_Location3;
        public InputAction @Location4 => m_Wrapper.m_Camera_Location4;
        public InputAction @SecondSetModifier => m_Wrapper.m_Camera_SecondSetModifier;
        public InputAction @OverwriteLocationModifier => m_Wrapper.m_Camera_OverwriteLocationModifier;
        public InputActionMap Get() { return m_Wrapper.m_Camera; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CameraActions set) { return set.Get(); }
        public void SetCallbacks(ICameraActions instance)
        {
            if (m_Wrapper.m_CameraActionsCallbackInterface != null)
            {
                @HoldtoMoveCamera.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnHoldtoMoveCamera;
                @HoldtoMoveCamera.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnHoldtoMoveCamera;
                @HoldtoMoveCamera.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnHoldtoMoveCamera;
                @MoveCamera.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnMoveCamera;
                @MoveCamera.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnMoveCamera;
                @RotateCamera.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnRotateCamera;
                @ElevateCamera.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnElevateCamera;
                @ElevateCamera.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnElevateCamera;
                @ElevateCamera.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnElevateCamera;
                @ToggleFullscreen.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnToggleFullscreen;
                @ToggleFullscreen.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnToggleFullscreen;
                @ToggleFullscreen.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnToggleFullscreen;
                @Location1.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnLocation1;
                @Location1.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnLocation1;
                @Location1.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnLocation1;
                @Location2.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnLocation2;
                @Location2.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnLocation2;
                @Location2.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnLocation2;
                @Location3.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnLocation3;
                @Location3.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnLocation3;
                @Location3.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnLocation3;
                @Location4.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnLocation4;
                @Location4.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnLocation4;
                @Location4.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnLocation4;
                @SecondSetModifier.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnSecondSetModifier;
                @SecondSetModifier.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnSecondSetModifier;
                @SecondSetModifier.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnSecondSetModifier;
                @OverwriteLocationModifier.started -= m_Wrapper.m_CameraActionsCallbackInterface.OnOverwriteLocationModifier;
                @OverwriteLocationModifier.performed -= m_Wrapper.m_CameraActionsCallbackInterface.OnOverwriteLocationModifier;
                @OverwriteLocationModifier.canceled -= m_Wrapper.m_CameraActionsCallbackInterface.OnOverwriteLocationModifier;
            }
            m_Wrapper.m_CameraActionsCallbackInterface = instance;
            if (instance != null)
            {
                @HoldtoMoveCamera.started += instance.OnHoldtoMoveCamera;
                @HoldtoMoveCamera.performed += instance.OnHoldtoMoveCamera;
                @HoldtoMoveCamera.canceled += instance.OnHoldtoMoveCamera;
                @MoveCamera.started += instance.OnMoveCamera;
                @MoveCamera.performed += instance.OnMoveCamera;
                @MoveCamera.canceled += instance.OnMoveCamera;
                @RotateCamera.started += instance.OnRotateCamera;
                @RotateCamera.performed += instance.OnRotateCamera;
                @RotateCamera.canceled += instance.OnRotateCamera;
                @ElevateCamera.started += instance.OnElevateCamera;
                @ElevateCamera.performed += instance.OnElevateCamera;
                @ElevateCamera.canceled += instance.OnElevateCamera;
                @ToggleFullscreen.started += instance.OnToggleFullscreen;
                @ToggleFullscreen.performed += instance.OnToggleFullscreen;
                @ToggleFullscreen.canceled += instance.OnToggleFullscreen;
                @Location1.started += instance.OnLocation1;
                @Location1.performed += instance.OnLocation1;
                @Location1.canceled += instance.OnLocation1;
                @Location2.started += instance.OnLocation2;
                @Location2.performed += instance.OnLocation2;
                @Location2.canceled += instance.OnLocation2;
                @Location3.started += instance.OnLocation3;
                @Location3.performed += instance.OnLocation3;
                @Location3.canceled += instance.OnLocation3;
                @Location4.started += instance.OnLocation4;
                @Location4.performed += instance.OnLocation4;
                @Location4.canceled += instance.OnLocation4;
                @SecondSetModifier.started += instance.OnSecondSetModifier;
                @SecondSetModifier.performed += instance.OnSecondSetModifier;
                @SecondSetModifier.canceled += instance.OnSecondSetModifier;
                @OverwriteLocationModifier.started += instance.OnOverwriteLocationModifier;
                @OverwriteLocationModifier.performed += instance.OnOverwriteLocationModifier;
                @OverwriteLocationModifier.canceled += instance.OnOverwriteLocationModifier;
            }
        }
    }
    public CameraActions @Camera => new CameraActions(this);

    // +Utils
    private readonly InputActionMap m_Utils;
    private IUtilsActions m_UtilsActionsCallbackInterface;
    private readonly InputAction m_Utils_ControlModifier;
    private readonly InputAction m_Utils_AltModifier;
    private readonly InputAction m_Utils_ShiftModifier;
    private readonly InputAction m_Utils_MouseMovement;
    public struct UtilsActions
    {
        private @CMInput m_Wrapper;
        public UtilsActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ControlModifier => m_Wrapper.m_Utils_ControlModifier;
        public InputAction @AltModifier => m_Wrapper.m_Utils_AltModifier;
        public InputAction @ShiftModifier => m_Wrapper.m_Utils_ShiftModifier;
        public InputAction @MouseMovement => m_Wrapper.m_Utils_MouseMovement;
        public InputActionMap Get() { return m_Wrapper.m_Utils; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UtilsActions set) { return set.Get(); }
        public void SetCallbacks(IUtilsActions instance)
        {
            if (m_Wrapper.m_UtilsActionsCallbackInterface != null)
            {
                @ControlModifier.started -= m_Wrapper.m_UtilsActionsCallbackInterface.OnControlModifier;
                @ControlModifier.performed -= m_Wrapper.m_UtilsActionsCallbackInterface.OnControlModifier;
                @ControlModifier.canceled -= m_Wrapper.m_UtilsActionsCallbackInterface.OnControlModifier;
                @AltModifier.started -= m_Wrapper.m_UtilsActionsCallbackInterface.OnAltModifier;
                @AltModifier.performed -= m_Wrapper.m_UtilsActionsCallbackInterface.OnAltModifier;
                @AltModifier.canceled -= m_Wrapper.m_UtilsActionsCallbackInterface.OnAltModifier;
                @ShiftModifier.started -= m_Wrapper.m_UtilsActionsCallbackInterface.OnShiftModifier;
                @ShiftModifier.performed -= m_Wrapper.m_UtilsActionsCallbackInterface.OnShiftModifier;
                @ShiftModifier.canceled -= m_Wrapper.m_UtilsActionsCallbackInterface.OnShiftModifier;
                @MouseMovement.started -= m_Wrapper.m_UtilsActionsCallbackInterface.OnMouseMovement;
                @MouseMovement.performed -= m_Wrapper.m_UtilsActionsCallbackInterface.OnMouseMovement;
                @MouseMovement.canceled -= m_Wrapper.m_UtilsActionsCallbackInterface.OnMouseMovement;
            }
            m_Wrapper.m_UtilsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ControlModifier.started += instance.OnControlModifier;
                @ControlModifier.performed += instance.OnControlModifier;
                @ControlModifier.canceled += instance.OnControlModifier;
                @AltModifier.started += instance.OnAltModifier;
                @AltModifier.performed += instance.OnAltModifier;
                @AltModifier.canceled += instance.OnAltModifier;
                @ShiftModifier.started += instance.OnShiftModifier;
                @ShiftModifier.performed += instance.OnShiftModifier;
                @ShiftModifier.canceled += instance.OnShiftModifier;
                @MouseMovement.started += instance.OnMouseMovement;
                @MouseMovement.performed += instance.OnMouseMovement;
                @MouseMovement.canceled += instance.OnMouseMovement;
            }
        }
    }
    public UtilsActions @Utils => new UtilsActions(this);

    // Actions
    private readonly InputActionMap m_Actions;
    private IActionsActions m_ActionsActionsCallbackInterface;
    private readonly InputAction m_Actions_UndoMethod1;
    private readonly InputAction m_Actions_UndoMethod2;
    private readonly InputAction m_Actions_RedoMethod1;
    private readonly InputAction m_Actions_RedoMethod2;
    public struct ActionsActions
    {
        private @CMInput m_Wrapper;
        public ActionsActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @UndoMethod1 => m_Wrapper.m_Actions_UndoMethod1;
        public InputAction @UndoMethod2 => m_Wrapper.m_Actions_UndoMethod2;
        public InputAction @RedoMethod1 => m_Wrapper.m_Actions_RedoMethod1;
        public InputAction @RedoMethod2 => m_Wrapper.m_Actions_RedoMethod2;
        public InputActionMap Get() { return m_Wrapper.m_Actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
        public void SetCallbacks(IActionsActions instance)
        {
            if (m_Wrapper.m_ActionsActionsCallbackInterface != null)
            {
                @UndoMethod1.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnUndoMethod1;
                @UndoMethod1.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnUndoMethod1;
                @UndoMethod1.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnUndoMethod1;
                @UndoMethod2.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnUndoMethod2;
                @UndoMethod2.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnUndoMethod2;
                @UndoMethod2.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnUndoMethod2;
                @RedoMethod1.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRedoMethod1;
                @RedoMethod1.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRedoMethod1;
                @RedoMethod1.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRedoMethod1;
                @RedoMethod2.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRedoMethod2;
                @RedoMethod2.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRedoMethod2;
                @RedoMethod2.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnRedoMethod2;
            }
            m_Wrapper.m_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @UndoMethod1.started += instance.OnUndoMethod1;
                @UndoMethod1.performed += instance.OnUndoMethod1;
                @UndoMethod1.canceled += instance.OnUndoMethod1;
                @UndoMethod2.started += instance.OnUndoMethod2;
                @UndoMethod2.performed += instance.OnUndoMethod2;
                @UndoMethod2.canceled += instance.OnUndoMethod2;
                @RedoMethod1.started += instance.OnRedoMethod1;
                @RedoMethod1.performed += instance.OnRedoMethod1;
                @RedoMethod1.canceled += instance.OnRedoMethod1;
                @RedoMethod2.started += instance.OnRedoMethod2;
                @RedoMethod2.performed += instance.OnRedoMethod2;
                @RedoMethod2.canceled += instance.OnRedoMethod2;
            }
        }
    }
    public ActionsActions @Actions => new ActionsActions(this);

    // Placement Controllers
    private readonly InputActionMap m_PlacementControllers;
    private IPlacementControllersActions m_PlacementControllersActionsCallbackInterface;
    private readonly InputAction m_PlacementControllers_PlaceObject;
    private readonly InputAction m_PlacementControllers_InitiateClickandDrag;
    private readonly InputAction m_PlacementControllers_InitiateClickandDragatTime;
    private readonly InputAction m_PlacementControllers_MousePositionUpdate;
    private readonly InputAction m_PlacementControllers_CancelPlacement;
    public struct PlacementControllersActions
    {
        private @CMInput m_Wrapper;
        public PlacementControllersActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlaceObject => m_Wrapper.m_PlacementControllers_PlaceObject;
        public InputAction @InitiateClickandDrag => m_Wrapper.m_PlacementControllers_InitiateClickandDrag;
        public InputAction @InitiateClickandDragatTime => m_Wrapper.m_PlacementControllers_InitiateClickandDragatTime;
        public InputAction @MousePositionUpdate => m_Wrapper.m_PlacementControllers_MousePositionUpdate;
        public InputAction @CancelPlacement => m_Wrapper.m_PlacementControllers_CancelPlacement;
        public InputActionMap Get() { return m_Wrapper.m_PlacementControllers; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlacementControllersActions set) { return set.Get(); }
        public void SetCallbacks(IPlacementControllersActions instance)
        {
            if (m_Wrapper.m_PlacementControllersActionsCallbackInterface != null)
            {
                @PlaceObject.started -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnPlaceObject;
                @PlaceObject.performed -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnPlaceObject;
                @PlaceObject.canceled -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnPlaceObject;
                @InitiateClickandDrag.started -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnInitiateClickandDrag;
                @InitiateClickandDrag.performed -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnInitiateClickandDrag;
                @InitiateClickandDrag.canceled -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnInitiateClickandDrag;
                @InitiateClickandDragatTime.started -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnInitiateClickandDragatTime;
                @InitiateClickandDragatTime.performed -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnInitiateClickandDragatTime;
                @InitiateClickandDragatTime.canceled -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnInitiateClickandDragatTime;
                @MousePositionUpdate.started -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnMousePositionUpdate;
                @MousePositionUpdate.performed -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnMousePositionUpdate;
                @MousePositionUpdate.canceled -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnMousePositionUpdate;
                @CancelPlacement.started -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnCancelPlacement;
                @CancelPlacement.performed -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnCancelPlacement;
                @CancelPlacement.canceled -= m_Wrapper.m_PlacementControllersActionsCallbackInterface.OnCancelPlacement;
            }
            m_Wrapper.m_PlacementControllersActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlaceObject.started += instance.OnPlaceObject;
                @PlaceObject.performed += instance.OnPlaceObject;
                @PlaceObject.canceled += instance.OnPlaceObject;
                @InitiateClickandDrag.started += instance.OnInitiateClickandDrag;
                @InitiateClickandDrag.performed += instance.OnInitiateClickandDrag;
                @InitiateClickandDrag.canceled += instance.OnInitiateClickandDrag;
                @InitiateClickandDragatTime.started += instance.OnInitiateClickandDragatTime;
                @InitiateClickandDragatTime.performed += instance.OnInitiateClickandDragatTime;
                @InitiateClickandDragatTime.canceled += instance.OnInitiateClickandDragatTime;
                @MousePositionUpdate.started += instance.OnMousePositionUpdate;
                @MousePositionUpdate.performed += instance.OnMousePositionUpdate;
                @MousePositionUpdate.canceled += instance.OnMousePositionUpdate;
                @CancelPlacement.started += instance.OnCancelPlacement;
                @CancelPlacement.performed += instance.OnCancelPlacement;
                @CancelPlacement.canceled += instance.OnCancelPlacement;
            }
        }
    }
    public PlacementControllersActions @PlacementControllers => new PlacementControllersActions(this);

    // Workflows
    private readonly InputActionMap m_Workflows;
    private IWorkflowsActions m_WorkflowsActionsCallbackInterface;
    private readonly InputAction m_Workflows_ToggleNoteColor;
    private readonly InputAction m_Workflows_PlaceRedNote;
    private readonly InputAction m_Workflows_PlaceBlueNote;
    private readonly InputAction m_Workflows_ToggleDeleteTool;
    private readonly InputAction m_Workflows_MirrorHorizontally;
    private readonly InputAction m_Workflows_MirrorVertically;
    private readonly InputAction m_Workflows_MirrorinTime;
    private readonly InputAction m_Workflows_MirrorColoursOnly;
    private readonly InputAction m_Workflows_SwapCursorInterval;
    public struct WorkflowsActions
    {
        private @CMInput m_Wrapper;
        public WorkflowsActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleNoteColor => m_Wrapper.m_Workflows_ToggleNoteColor;
        public InputAction @PlaceRedNote => m_Wrapper.m_Workflows_PlaceRedNote;
        public InputAction @PlaceBlueNote => m_Wrapper.m_Workflows_PlaceBlueNote;
        public InputAction @ToggleDeleteTool => m_Wrapper.m_Workflows_ToggleDeleteTool;
        public InputAction @MirrorHorizontally => m_Wrapper.m_Workflows_MirrorHorizontally;
        public InputAction @MirrorVertically => m_Wrapper.m_Workflows_MirrorVertically;
        public InputAction @MirrorinTime => m_Wrapper.m_Workflows_MirrorinTime;
        public InputAction @MirrorColoursOnly => m_Wrapper.m_Workflows_MirrorColoursOnly;
        public InputAction @SwapCursorInterval => m_Wrapper.m_Workflows_SwapCursorInterval;
        public InputActionMap Get() { return m_Wrapper.m_Workflows; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WorkflowsActions set) { return set.Get(); }
        public void SetCallbacks(IWorkflowsActions instance)
        {
            if (m_Wrapper.m_WorkflowsActionsCallbackInterface != null)
            {
                @ToggleNoteColor.started -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnToggleNoteColor;
                @ToggleNoteColor.performed -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnToggleNoteColor;
                @ToggleNoteColor.canceled -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnToggleNoteColor;
                @PlaceRedNote.started -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnPlaceRedNote;
                @PlaceRedNote.performed -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnPlaceRedNote;
                @PlaceRedNote.canceled -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnPlaceRedNote;
                @PlaceBlueNote.started -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnPlaceBlueNote;
                @PlaceBlueNote.performed -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnPlaceBlueNote;
                @PlaceBlueNote.canceled -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnPlaceBlueNote;
                @ToggleDeleteTool.started -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnToggleDeleteTool;
                @ToggleDeleteTool.performed -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnToggleDeleteTool;
                @ToggleDeleteTool.canceled -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnToggleDeleteTool;
                @MirrorHorizontally.started -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnMirrorHorizontally;
                @MirrorHorizontally.performed -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnMirrorHorizontally;
                @MirrorHorizontally.canceled -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnMirrorHorizontally;
                @MirrorVertically.started -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnMirrorVertically;
                @MirrorVertically.performed -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnMirrorVertically;
                @MirrorVertically.canceled -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnMirrorVertically;
                @MirrorinTime.started -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnMirrorinTime;
                @MirrorinTime.performed -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnMirrorinTime;
                @MirrorinTime.canceled -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnMirrorinTime;
                @MirrorColoursOnly.started -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnMirrorColoursOnly;
                @MirrorColoursOnly.performed -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnMirrorColoursOnly;
                @MirrorColoursOnly.canceled -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnMirrorColoursOnly;
                @SwapCursorInterval.started -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnSwapCursorInterval;
                @SwapCursorInterval.performed -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnSwapCursorInterval;
                @SwapCursorInterval.canceled -= m_Wrapper.m_WorkflowsActionsCallbackInterface.OnSwapCursorInterval;
            }
            m_Wrapper.m_WorkflowsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleNoteColor.started += instance.OnToggleNoteColor;
                @ToggleNoteColor.performed += instance.OnToggleNoteColor;
                @ToggleNoteColor.canceled += instance.OnToggleNoteColor;
                @PlaceRedNote.started += instance.OnPlaceRedNote;
                @PlaceRedNote.performed += instance.OnPlaceRedNote;
                @PlaceRedNote.canceled += instance.OnPlaceRedNote;
                @PlaceBlueNote.started += instance.OnPlaceBlueNote;
                @PlaceBlueNote.performed += instance.OnPlaceBlueNote;
                @PlaceBlueNote.canceled += instance.OnPlaceBlueNote;
                @ToggleDeleteTool.started += instance.OnToggleDeleteTool;
                @ToggleDeleteTool.performed += instance.OnToggleDeleteTool;
                @ToggleDeleteTool.canceled += instance.OnToggleDeleteTool;
                @MirrorHorizontally.started += instance.OnMirrorHorizontally;
                @MirrorHorizontally.performed += instance.OnMirrorHorizontally;
                @MirrorHorizontally.canceled += instance.OnMirrorHorizontally;
                @MirrorVertically.started += instance.OnMirrorVertically;
                @MirrorVertically.performed += instance.OnMirrorVertically;
                @MirrorVertically.canceled += instance.OnMirrorVertically;
                @MirrorinTime.started += instance.OnMirrorinTime;
                @MirrorinTime.performed += instance.OnMirrorinTime;
                @MirrorinTime.canceled += instance.OnMirrorinTime;
                @MirrorColoursOnly.started += instance.OnMirrorColoursOnly;
                @MirrorColoursOnly.performed += instance.OnMirrorColoursOnly;
                @MirrorColoursOnly.canceled += instance.OnMirrorColoursOnly;
                @SwapCursorInterval.started += instance.OnSwapCursorInterval;
                @SwapCursorInterval.performed += instance.OnSwapCursorInterval;
                @SwapCursorInterval.canceled += instance.OnSwapCursorInterval;
            }
        }
    }
    public WorkflowsActions @Workflows => new WorkflowsActions(this);

    // Saving
    private readonly InputActionMap m_Saving;
    private ISavingActions m_SavingActionsCallbackInterface;
    private readonly InputAction m_Saving_Save;
    public struct SavingActions
    {
        private @CMInput m_Wrapper;
        public SavingActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Save => m_Wrapper.m_Saving_Save;
        public InputActionMap Get() { return m_Wrapper.m_Saving; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SavingActions set) { return set.Get(); }
        public void SetCallbacks(ISavingActions instance)
        {
            if (m_Wrapper.m_SavingActionsCallbackInterface != null)
            {
                @Save.started -= m_Wrapper.m_SavingActionsCallbackInterface.OnSave;
                @Save.performed -= m_Wrapper.m_SavingActionsCallbackInterface.OnSave;
                @Save.canceled -= m_Wrapper.m_SavingActionsCallbackInterface.OnSave;
            }
            m_Wrapper.m_SavingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Save.started += instance.OnSave;
                @Save.performed += instance.OnSave;
                @Save.canceled += instance.OnSave;
            }
        }
    }
    public SavingActions @Saving => new SavingActions(this);

    // Bookmarks
    private readonly InputActionMap m_Bookmarks;
    private IBookmarksActions m_BookmarksActionsCallbackInterface;
    private readonly InputAction m_Bookmarks_CreateNewBookmark;
    private readonly InputAction m_Bookmarks_NextBookmark;
    private readonly InputAction m_Bookmarks_PreviousBookmark;
    private readonly InputAction m_Bookmarks_ColorBookmarkModifier;
    public struct BookmarksActions
    {
        private @CMInput m_Wrapper;
        public BookmarksActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @CreateNewBookmark => m_Wrapper.m_Bookmarks_CreateNewBookmark;
        public InputAction @NextBookmark => m_Wrapper.m_Bookmarks_NextBookmark;
        public InputAction @PreviousBookmark => m_Wrapper.m_Bookmarks_PreviousBookmark;
        public InputAction @ColorBookmarkModifier => m_Wrapper.m_Bookmarks_ColorBookmarkModifier;
        public InputActionMap Get() { return m_Wrapper.m_Bookmarks; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BookmarksActions set) { return set.Get(); }
        public void SetCallbacks(IBookmarksActions instance)
        {
            if (m_Wrapper.m_BookmarksActionsCallbackInterface != null)
            {
                @CreateNewBookmark.started -= m_Wrapper.m_BookmarksActionsCallbackInterface.OnCreateNewBookmark;
                @CreateNewBookmark.performed -= m_Wrapper.m_BookmarksActionsCallbackInterface.OnCreateNewBookmark;
                @CreateNewBookmark.canceled -= m_Wrapper.m_BookmarksActionsCallbackInterface.OnCreateNewBookmark;
                @NextBookmark.started -= m_Wrapper.m_BookmarksActionsCallbackInterface.OnNextBookmark;
                @NextBookmark.performed -= m_Wrapper.m_BookmarksActionsCallbackInterface.OnNextBookmark;
                @NextBookmark.canceled -= m_Wrapper.m_BookmarksActionsCallbackInterface.OnNextBookmark;
                @PreviousBookmark.started -= m_Wrapper.m_BookmarksActionsCallbackInterface.OnPreviousBookmark;
                @PreviousBookmark.performed -= m_Wrapper.m_BookmarksActionsCallbackInterface.OnPreviousBookmark;
                @PreviousBookmark.canceled -= m_Wrapper.m_BookmarksActionsCallbackInterface.OnPreviousBookmark;
                @ColorBookmarkModifier.started -= m_Wrapper.m_BookmarksActionsCallbackInterface.OnColorBookmarkModifier;
                @ColorBookmarkModifier.performed -= m_Wrapper.m_BookmarksActionsCallbackInterface.OnColorBookmarkModifier;
                @ColorBookmarkModifier.canceled -= m_Wrapper.m_BookmarksActionsCallbackInterface.OnColorBookmarkModifier;
            }
            m_Wrapper.m_BookmarksActionsCallbackInterface = instance;
            if (instance != null)
            {
                @CreateNewBookmark.started += instance.OnCreateNewBookmark;
                @CreateNewBookmark.performed += instance.OnCreateNewBookmark;
                @CreateNewBookmark.canceled += instance.OnCreateNewBookmark;
                @NextBookmark.started += instance.OnNextBookmark;
                @NextBookmark.performed += instance.OnNextBookmark;
                @NextBookmark.canceled += instance.OnNextBookmark;
                @PreviousBookmark.started += instance.OnPreviousBookmark;
                @PreviousBookmark.performed += instance.OnPreviousBookmark;
                @PreviousBookmark.canceled += instance.OnPreviousBookmark;
                @ColorBookmarkModifier.started += instance.OnColorBookmarkModifier;
                @ColorBookmarkModifier.performed += instance.OnColorBookmarkModifier;
                @ColorBookmarkModifier.canceled += instance.OnColorBookmarkModifier;
            }
        }
    }
    public BookmarksActions @Bookmarks => new BookmarksActions(this);

    // Refresh Map
    private readonly InputActionMap m_RefreshMap;
    private IRefreshMapActions m_RefreshMapActionsCallbackInterface;
    private readonly InputAction m_RefreshMap_RefreshMap;
    public struct RefreshMapActions
    {
        private @CMInput m_Wrapper;
        public RefreshMapActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @RefreshMap => m_Wrapper.m_RefreshMap_RefreshMap;
        public InputActionMap Get() { return m_Wrapper.m_RefreshMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RefreshMapActions set) { return set.Get(); }
        public void SetCallbacks(IRefreshMapActions instance)
        {
            if (m_Wrapper.m_RefreshMapActionsCallbackInterface != null)
            {
                @RefreshMap.started -= m_Wrapper.m_RefreshMapActionsCallbackInterface.OnRefreshMap;
                @RefreshMap.performed -= m_Wrapper.m_RefreshMapActionsCallbackInterface.OnRefreshMap;
                @RefreshMap.canceled -= m_Wrapper.m_RefreshMapActionsCallbackInterface.OnRefreshMap;
            }
            m_Wrapper.m_RefreshMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RefreshMap.started += instance.OnRefreshMap;
                @RefreshMap.performed += instance.OnRefreshMap;
                @RefreshMap.canceled += instance.OnRefreshMap;
            }
        }
    }
    public RefreshMapActions @RefreshMap => new RefreshMapActions(this);

    // Playback
    private readonly InputActionMap m_Playback;
    private IPlaybackActions m_PlaybackActionsCallbackInterface;
    private readonly InputAction m_Playback_TogglePlaying;
    private readonly InputAction m_Playback_ResetTime;
    public struct PlaybackActions
    {
        private @CMInput m_Wrapper;
        public PlaybackActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @TogglePlaying => m_Wrapper.m_Playback_TogglePlaying;
        public InputAction @ResetTime => m_Wrapper.m_Playback_ResetTime;
        public InputActionMap Get() { return m_Wrapper.m_Playback; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlaybackActions set) { return set.Get(); }
        public void SetCallbacks(IPlaybackActions instance)
        {
            if (m_Wrapper.m_PlaybackActionsCallbackInterface != null)
            {
                @TogglePlaying.started -= m_Wrapper.m_PlaybackActionsCallbackInterface.OnTogglePlaying;
                @TogglePlaying.performed -= m_Wrapper.m_PlaybackActionsCallbackInterface.OnTogglePlaying;
                @TogglePlaying.canceled -= m_Wrapper.m_PlaybackActionsCallbackInterface.OnTogglePlaying;
                @ResetTime.started -= m_Wrapper.m_PlaybackActionsCallbackInterface.OnResetTime;
                @ResetTime.performed -= m_Wrapper.m_PlaybackActionsCallbackInterface.OnResetTime;
                @ResetTime.canceled -= m_Wrapper.m_PlaybackActionsCallbackInterface.OnResetTime;
            }
            m_Wrapper.m_PlaybackActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TogglePlaying.started += instance.OnTogglePlaying;
                @TogglePlaying.performed += instance.OnTogglePlaying;
                @TogglePlaying.canceled += instance.OnTogglePlaying;
                @ResetTime.started += instance.OnResetTime;
                @ResetTime.performed += instance.OnResetTime;
                @ResetTime.canceled += instance.OnResetTime;
            }
        }
    }
    public PlaybackActions @Playback => new PlaybackActions(this);

    // Timeline
    private readonly InputActionMap m_Timeline;
    private ITimelineActions m_TimelineActionsCallbackInterface;
    private readonly InputAction m_Timeline_ChangeTimeandPrecision;
    private readonly InputAction m_Timeline_ChangePrecisionModifier;
    private readonly InputAction m_Timeline_PreciseSnapModification;
    public struct TimelineActions
    {
        private @CMInput m_Wrapper;
        public TimelineActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ChangeTimeandPrecision => m_Wrapper.m_Timeline_ChangeTimeandPrecision;
        public InputAction @ChangePrecisionModifier => m_Wrapper.m_Timeline_ChangePrecisionModifier;
        public InputAction @PreciseSnapModification => m_Wrapper.m_Timeline_PreciseSnapModification;
        public InputActionMap Get() { return m_Wrapper.m_Timeline; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TimelineActions set) { return set.Get(); }
        public void SetCallbacks(ITimelineActions instance)
        {
            if (m_Wrapper.m_TimelineActionsCallbackInterface != null)
            {
                @ChangeTimeandPrecision.started -= m_Wrapper.m_TimelineActionsCallbackInterface.OnChangeTimeandPrecision;
                @ChangeTimeandPrecision.performed -= m_Wrapper.m_TimelineActionsCallbackInterface.OnChangeTimeandPrecision;
                @ChangeTimeandPrecision.canceled -= m_Wrapper.m_TimelineActionsCallbackInterface.OnChangeTimeandPrecision;
                @ChangePrecisionModifier.started -= m_Wrapper.m_TimelineActionsCallbackInterface.OnChangePrecisionModifier;
                @ChangePrecisionModifier.performed -= m_Wrapper.m_TimelineActionsCallbackInterface.OnChangePrecisionModifier;
                @ChangePrecisionModifier.canceled -= m_Wrapper.m_TimelineActionsCallbackInterface.OnChangePrecisionModifier;
                @PreciseSnapModification.started -= m_Wrapper.m_TimelineActionsCallbackInterface.OnPreciseSnapModification;
                @PreciseSnapModification.performed -= m_Wrapper.m_TimelineActionsCallbackInterface.OnPreciseSnapModification;
                @PreciseSnapModification.canceled -= m_Wrapper.m_TimelineActionsCallbackInterface.OnPreciseSnapModification;
            }
            m_Wrapper.m_TimelineActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ChangeTimeandPrecision.started += instance.OnChangeTimeandPrecision;
                @ChangeTimeandPrecision.performed += instance.OnChangeTimeandPrecision;
                @ChangeTimeandPrecision.canceled += instance.OnChangeTimeandPrecision;
                @ChangePrecisionModifier.started += instance.OnChangePrecisionModifier;
                @ChangePrecisionModifier.performed += instance.OnChangePrecisionModifier;
                @ChangePrecisionModifier.canceled += instance.OnChangePrecisionModifier;
                @PreciseSnapModification.started += instance.OnPreciseSnapModification;
                @PreciseSnapModification.performed += instance.OnPreciseSnapModification;
                @PreciseSnapModification.canceled += instance.OnPreciseSnapModification;
            }
        }
    }
    public TimelineActions @Timeline => new TimelineActions(this);

    // Editor Scale
    private readonly InputActionMap m_EditorScale;
    private IEditorScaleActions m_EditorScaleActionsCallbackInterface;
    private readonly InputAction m_EditorScale_DecreaseEditorScale;
    private readonly InputAction m_EditorScale_IncreaseEditorScale;
    public struct EditorScaleActions
    {
        private @CMInput m_Wrapper;
        public EditorScaleActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @DecreaseEditorScale => m_Wrapper.m_EditorScale_DecreaseEditorScale;
        public InputAction @IncreaseEditorScale => m_Wrapper.m_EditorScale_IncreaseEditorScale;
        public InputActionMap Get() { return m_Wrapper.m_EditorScale; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(EditorScaleActions set) { return set.Get(); }
        public void SetCallbacks(IEditorScaleActions instance)
        {
            if (m_Wrapper.m_EditorScaleActionsCallbackInterface != null)
            {
                @DecreaseEditorScale.started -= m_Wrapper.m_EditorScaleActionsCallbackInterface.OnDecreaseEditorScale;
                @DecreaseEditorScale.performed -= m_Wrapper.m_EditorScaleActionsCallbackInterface.OnDecreaseEditorScale;
                @DecreaseEditorScale.canceled -= m_Wrapper.m_EditorScaleActionsCallbackInterface.OnDecreaseEditorScale;
                @IncreaseEditorScale.started -= m_Wrapper.m_EditorScaleActionsCallbackInterface.OnIncreaseEditorScale;
                @IncreaseEditorScale.performed -= m_Wrapper.m_EditorScaleActionsCallbackInterface.OnIncreaseEditorScale;
                @IncreaseEditorScale.canceled -= m_Wrapper.m_EditorScaleActionsCallbackInterface.OnIncreaseEditorScale;
            }
            m_Wrapper.m_EditorScaleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DecreaseEditorScale.started += instance.OnDecreaseEditorScale;
                @DecreaseEditorScale.performed += instance.OnDecreaseEditorScale;
                @DecreaseEditorScale.canceled += instance.OnDecreaseEditorScale;
                @IncreaseEditorScale.started += instance.OnIncreaseEditorScale;
                @IncreaseEditorScale.performed += instance.OnIncreaseEditorScale;
                @IncreaseEditorScale.canceled += instance.OnIncreaseEditorScale;
            }
        }
    }
    public EditorScaleActions @EditorScale => new EditorScaleActions(this);

    // Beatmap Objects
    private readonly InputActionMap m_BeatmapObjects;
    private IBeatmapObjectsActions m_BeatmapObjectsActionsCallbackInterface;
    private readonly InputAction m_BeatmapObjects_SelectObjects;
    private readonly InputAction m_BeatmapObjects_MassSelectModifier;
    private readonly InputAction m_BeatmapObjects_QuickDelete;
    private readonly InputAction m_BeatmapObjects_DeleteTool;
    private readonly InputAction m_BeatmapObjects_MousePositionUpdate;
    private readonly InputAction m_BeatmapObjects_JumptoObjectTime;
    public struct BeatmapObjectsActions
    {
        private @CMInput m_Wrapper;
        public BeatmapObjectsActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @SelectObjects => m_Wrapper.m_BeatmapObjects_SelectObjects;
        public InputAction @MassSelectModifier => m_Wrapper.m_BeatmapObjects_MassSelectModifier;
        public InputAction @QuickDelete => m_Wrapper.m_BeatmapObjects_QuickDelete;
        public InputAction @DeleteTool => m_Wrapper.m_BeatmapObjects_DeleteTool;
        public InputAction @MousePositionUpdate => m_Wrapper.m_BeatmapObjects_MousePositionUpdate;
        public InputAction @JumptoObjectTime => m_Wrapper.m_BeatmapObjects_JumptoObjectTime;
        public InputActionMap Get() { return m_Wrapper.m_BeatmapObjects; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BeatmapObjectsActions set) { return set.Get(); }
        public void SetCallbacks(IBeatmapObjectsActions instance)
        {
            if (m_Wrapper.m_BeatmapObjectsActionsCallbackInterface != null)
            {
                @SelectObjects.started -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnSelectObjects;
                @SelectObjects.performed -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnSelectObjects;
                @SelectObjects.canceled -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnSelectObjects;
                @MassSelectModifier.started -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnMassSelectModifier;
                @MassSelectModifier.performed -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnMassSelectModifier;
                @MassSelectModifier.canceled -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnMassSelectModifier;
                @QuickDelete.started -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnQuickDelete;
                @QuickDelete.performed -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnQuickDelete;
                @QuickDelete.canceled -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnQuickDelete;
                @DeleteTool.started -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnDeleteTool;
                @DeleteTool.performed -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnDeleteTool;
                @DeleteTool.canceled -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnDeleteTool;
                @MousePositionUpdate.started -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnMousePositionUpdate;
                @MousePositionUpdate.performed -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnMousePositionUpdate;
                @MousePositionUpdate.canceled -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnMousePositionUpdate;
                @JumptoObjectTime.started -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnJumptoObjectTime;
                @JumptoObjectTime.performed -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnJumptoObjectTime;
                @JumptoObjectTime.canceled -= m_Wrapper.m_BeatmapObjectsActionsCallbackInterface.OnJumptoObjectTime;
            }
            m_Wrapper.m_BeatmapObjectsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SelectObjects.started += instance.OnSelectObjects;
                @SelectObjects.performed += instance.OnSelectObjects;
                @SelectObjects.canceled += instance.OnSelectObjects;
                @MassSelectModifier.started += instance.OnMassSelectModifier;
                @MassSelectModifier.performed += instance.OnMassSelectModifier;
                @MassSelectModifier.canceled += instance.OnMassSelectModifier;
                @QuickDelete.started += instance.OnQuickDelete;
                @QuickDelete.performed += instance.OnQuickDelete;
                @QuickDelete.canceled += instance.OnQuickDelete;
                @DeleteTool.started += instance.OnDeleteTool;
                @DeleteTool.performed += instance.OnDeleteTool;
                @DeleteTool.canceled += instance.OnDeleteTool;
                @MousePositionUpdate.started += instance.OnMousePositionUpdate;
                @MousePositionUpdate.performed += instance.OnMousePositionUpdate;
                @MousePositionUpdate.canceled += instance.OnMousePositionUpdate;
                @JumptoObjectTime.started += instance.OnJumptoObjectTime;
                @JumptoObjectTime.performed += instance.OnJumptoObjectTime;
                @JumptoObjectTime.canceled += instance.OnJumptoObjectTime;
            }
        }
    }
    public BeatmapObjectsActions @BeatmapObjects => new BeatmapObjectsActions(this);

    // Note Objects
    private readonly InputActionMap m_NoteObjects;
    private INoteObjectsActions m_NoteObjectsActionsCallbackInterface;
    private readonly InputAction m_NoteObjects_InvertNoteColors;
    private readonly InputAction m_NoteObjects_QuickDirectionModifier;
    public struct NoteObjectsActions
    {
        private @CMInput m_Wrapper;
        public NoteObjectsActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @InvertNoteColors => m_Wrapper.m_NoteObjects_InvertNoteColors;
        public InputAction @QuickDirectionModifier => m_Wrapper.m_NoteObjects_QuickDirectionModifier;
        public InputActionMap Get() { return m_Wrapper.m_NoteObjects; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NoteObjectsActions set) { return set.Get(); }
        public void SetCallbacks(INoteObjectsActions instance)
        {
            if (m_Wrapper.m_NoteObjectsActionsCallbackInterface != null)
            {
                @InvertNoteColors.started -= m_Wrapper.m_NoteObjectsActionsCallbackInterface.OnInvertNoteColors;
                @InvertNoteColors.performed -= m_Wrapper.m_NoteObjectsActionsCallbackInterface.OnInvertNoteColors;
                @InvertNoteColors.canceled -= m_Wrapper.m_NoteObjectsActionsCallbackInterface.OnInvertNoteColors;
                @QuickDirectionModifier.started -= m_Wrapper.m_NoteObjectsActionsCallbackInterface.OnQuickDirectionModifier;
                @QuickDirectionModifier.performed -= m_Wrapper.m_NoteObjectsActionsCallbackInterface.OnQuickDirectionModifier;
                @QuickDirectionModifier.canceled -= m_Wrapper.m_NoteObjectsActionsCallbackInterface.OnQuickDirectionModifier;
            }
            m_Wrapper.m_NoteObjectsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @InvertNoteColors.started += instance.OnInvertNoteColors;
                @InvertNoteColors.performed += instance.OnInvertNoteColors;
                @InvertNoteColors.canceled += instance.OnInvertNoteColors;
                @QuickDirectionModifier.started += instance.OnQuickDirectionModifier;
                @QuickDirectionModifier.performed += instance.OnQuickDirectionModifier;
                @QuickDirectionModifier.canceled += instance.OnQuickDirectionModifier;
            }
        }
    }
    public NoteObjectsActions @NoteObjects => new NoteObjectsActions(this);

    // BPM Change Objects
    private readonly InputActionMap m_BPMChangeObjects;
    private IBPMChangeObjectsActions m_BPMChangeObjectsActionsCallbackInterface;
    private readonly InputAction m_BPMChangeObjects_ReplaceBPM;
    private readonly InputAction m_BPMChangeObjects_TweakBPMValue;
    public struct BPMChangeObjectsActions
    {
        private @CMInput m_Wrapper;
        public BPMChangeObjectsActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ReplaceBPM => m_Wrapper.m_BPMChangeObjects_ReplaceBPM;
        public InputAction @TweakBPMValue => m_Wrapper.m_BPMChangeObjects_TweakBPMValue;
        public InputActionMap Get() { return m_Wrapper.m_BPMChangeObjects; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BPMChangeObjectsActions set) { return set.Get(); }
        public void SetCallbacks(IBPMChangeObjectsActions instance)
        {
            if (m_Wrapper.m_BPMChangeObjectsActionsCallbackInterface != null)
            {
                @ReplaceBPM.started -= m_Wrapper.m_BPMChangeObjectsActionsCallbackInterface.OnReplaceBPM;
                @ReplaceBPM.performed -= m_Wrapper.m_BPMChangeObjectsActionsCallbackInterface.OnReplaceBPM;
                @ReplaceBPM.canceled -= m_Wrapper.m_BPMChangeObjectsActionsCallbackInterface.OnReplaceBPM;
                @TweakBPMValue.started -= m_Wrapper.m_BPMChangeObjectsActionsCallbackInterface.OnTweakBPMValue;
                @TweakBPMValue.performed -= m_Wrapper.m_BPMChangeObjectsActionsCallbackInterface.OnTweakBPMValue;
                @TweakBPMValue.canceled -= m_Wrapper.m_BPMChangeObjectsActionsCallbackInterface.OnTweakBPMValue;
            }
            m_Wrapper.m_BPMChangeObjectsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ReplaceBPM.started += instance.OnReplaceBPM;
                @ReplaceBPM.performed += instance.OnReplaceBPM;
                @ReplaceBPM.canceled += instance.OnReplaceBPM;
                @TweakBPMValue.started += instance.OnTweakBPMValue;
                @TweakBPMValue.performed += instance.OnTweakBPMValue;
                @TweakBPMValue.canceled += instance.OnTweakBPMValue;
            }
        }
    }
    public BPMChangeObjectsActions @BPMChangeObjects => new BPMChangeObjectsActions(this);

    // Box Select
    private readonly InputActionMap m_BoxSelect;
    private IBoxSelectActions m_BoxSelectActionsCallbackInterface;
    private readonly InputAction m_BoxSelect_ActivateBoxSelect;
    public struct BoxSelectActions
    {
        private @CMInput m_Wrapper;
        public BoxSelectActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ActivateBoxSelect => m_Wrapper.m_BoxSelect_ActivateBoxSelect;
        public InputActionMap Get() { return m_Wrapper.m_BoxSelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BoxSelectActions set) { return set.Get(); }
        public void SetCallbacks(IBoxSelectActions instance)
        {
            if (m_Wrapper.m_BoxSelectActionsCallbackInterface != null)
            {
                @ActivateBoxSelect.started -= m_Wrapper.m_BoxSelectActionsCallbackInterface.OnActivateBoxSelect;
                @ActivateBoxSelect.performed -= m_Wrapper.m_BoxSelectActionsCallbackInterface.OnActivateBoxSelect;
                @ActivateBoxSelect.canceled -= m_Wrapper.m_BoxSelectActionsCallbackInterface.OnActivateBoxSelect;
            }
            m_Wrapper.m_BoxSelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ActivateBoxSelect.started += instance.OnActivateBoxSelect;
                @ActivateBoxSelect.performed += instance.OnActivateBoxSelect;
                @ActivateBoxSelect.canceled += instance.OnActivateBoxSelect;
            }
        }
    }
    public BoxSelectActions @BoxSelect => new BoxSelectActions(this);

    // BPM Tapper
    private readonly InputActionMap m_BPMTapper;
    private IBPMTapperActions m_BPMTapperActionsCallbackInterface;
    private readonly InputAction m_BPMTapper_ToggleBPMTapper;
    public struct BPMTapperActions
    {
        private @CMInput m_Wrapper;
        public BPMTapperActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleBPMTapper => m_Wrapper.m_BPMTapper_ToggleBPMTapper;
        public InputActionMap Get() { return m_Wrapper.m_BPMTapper; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BPMTapperActions set) { return set.Get(); }
        public void SetCallbacks(IBPMTapperActions instance)
        {
            if (m_Wrapper.m_BPMTapperActionsCallbackInterface != null)
            {
                @ToggleBPMTapper.started -= m_Wrapper.m_BPMTapperActionsCallbackInterface.OnToggleBPMTapper;
                @ToggleBPMTapper.performed -= m_Wrapper.m_BPMTapperActionsCallbackInterface.OnToggleBPMTapper;
                @ToggleBPMTapper.canceled -= m_Wrapper.m_BPMTapperActionsCallbackInterface.OnToggleBPMTapper;
            }
            m_Wrapper.m_BPMTapperActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleBPMTapper.started += instance.OnToggleBPMTapper;
                @ToggleBPMTapper.performed += instance.OnToggleBPMTapper;
                @ToggleBPMTapper.canceled += instance.OnToggleBPMTapper;
            }
        }
    }
    public BPMTapperActions @BPMTapper => new BPMTapperActions(this);

    // Pause Menu
    private readonly InputActionMap m_PauseMenu;
    private IPauseMenuActions m_PauseMenuActionsCallbackInterface;
    private readonly InputAction m_PauseMenu_PauseEditor;
    public struct PauseMenuActions
    {
        private @CMInput m_Wrapper;
        public PauseMenuActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseEditor => m_Wrapper.m_PauseMenu_PauseEditor;
        public InputActionMap Get() { return m_Wrapper.m_PauseMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseMenuActions set) { return set.Get(); }
        public void SetCallbacks(IPauseMenuActions instance)
        {
            if (m_Wrapper.m_PauseMenuActionsCallbackInterface != null)
            {
                @PauseEditor.started -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPauseEditor;
                @PauseEditor.performed -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPauseEditor;
                @PauseEditor.canceled -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPauseEditor;
            }
            m_Wrapper.m_PauseMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseEditor.started += instance.OnPauseEditor;
                @PauseEditor.performed += instance.OnPauseEditor;
                @PauseEditor.canceled += instance.OnPauseEditor;
            }
        }
    }
    public PauseMenuActions @PauseMenu => new PauseMenuActions(this);

    // Selection
    private readonly InputActionMap m_Selection;
    private ISelectionActions m_SelectionActionsCallbackInterface;
    private readonly InputAction m_Selection_DeselectAll;
    private readonly InputAction m_Selection_DeleteObjects;
    private readonly InputAction m_Selection_Cut;
    private readonly InputAction m_Selection_Paste;
    private readonly InputAction m_Selection_Copy;
    private readonly InputAction m_Selection_OverwritePaste;
    private readonly InputAction m_Selection_RotateSelection;
    private readonly InputAction m_Selection_ShiftSelectionForward;
    private readonly InputAction m_Selection_ShiftSelectionBackward;
    public struct SelectionActions
    {
        private @CMInput m_Wrapper;
        public SelectionActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @DeselectAll => m_Wrapper.m_Selection_DeselectAll;
        public InputAction @DeleteObjects => m_Wrapper.m_Selection_DeleteObjects;
        public InputAction @Cut => m_Wrapper.m_Selection_Cut;
        public InputAction @Paste => m_Wrapper.m_Selection_Paste;
        public InputAction @Copy => m_Wrapper.m_Selection_Copy;
        public InputAction @OverwritePaste => m_Wrapper.m_Selection_OverwritePaste;
        public InputAction @RotateSelection => m_Wrapper.m_Selection_RotateSelection;
        public InputAction @ShiftSelectionForward => m_Wrapper.m_Selection_ShiftSelectionForward;
        public InputAction @ShiftSelectionBackward => m_Wrapper.m_Selection_ShiftSelectionBackward;
        public InputActionMap Get() { return m_Wrapper.m_Selection; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SelectionActions set) { return set.Get(); }
        public void SetCallbacks(ISelectionActions instance)
        {
            if (m_Wrapper.m_SelectionActionsCallbackInterface != null)
            {
                @DeselectAll.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnDeselectAll;
                @DeselectAll.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnDeselectAll;
                @DeselectAll.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnDeselectAll;
                @DeleteObjects.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnDeleteObjects;
                @DeleteObjects.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnDeleteObjects;
                @DeleteObjects.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnDeleteObjects;
                @Cut.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnCut;
                @Cut.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnCut;
                @Cut.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnCut;
                @Paste.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnPaste;
                @Paste.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnPaste;
                @Paste.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnPaste;
                @Copy.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnCopy;
                @Copy.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnCopy;
                @Copy.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnCopy;
                @OverwritePaste.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnOverwritePaste;
                @OverwritePaste.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnOverwritePaste;
                @OverwritePaste.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnOverwritePaste;
                @RotateSelection.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnRotateSelection;
                @RotateSelection.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnRotateSelection;
                @RotateSelection.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnRotateSelection;
                @ShiftSelectionForward.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnShiftSelectionForward;
                @ShiftSelectionForward.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnShiftSelectionForward;
                @ShiftSelectionForward.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnShiftSelectionForward;
                @ShiftSelectionBackward.started -= m_Wrapper.m_SelectionActionsCallbackInterface.OnShiftSelectionBackward;
                @ShiftSelectionBackward.performed -= m_Wrapper.m_SelectionActionsCallbackInterface.OnShiftSelectionBackward;
                @ShiftSelectionBackward.canceled -= m_Wrapper.m_SelectionActionsCallbackInterface.OnShiftSelectionBackward;
            }
            m_Wrapper.m_SelectionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DeselectAll.started += instance.OnDeselectAll;
                @DeselectAll.performed += instance.OnDeselectAll;
                @DeselectAll.canceled += instance.OnDeselectAll;
                @DeleteObjects.started += instance.OnDeleteObjects;
                @DeleteObjects.performed += instance.OnDeleteObjects;
                @DeleteObjects.canceled += instance.OnDeleteObjects;
                @Cut.started += instance.OnCut;
                @Cut.performed += instance.OnCut;
                @Cut.canceled += instance.OnCut;
                @Paste.started += instance.OnPaste;
                @Paste.performed += instance.OnPaste;
                @Paste.canceled += instance.OnPaste;
                @Copy.started += instance.OnCopy;
                @Copy.performed += instance.OnCopy;
                @Copy.canceled += instance.OnCopy;
                @OverwritePaste.started += instance.OnOverwritePaste;
                @OverwritePaste.performed += instance.OnOverwritePaste;
                @OverwritePaste.canceled += instance.OnOverwritePaste;
                @RotateSelection.started += instance.OnRotateSelection;
                @RotateSelection.performed += instance.OnRotateSelection;
                @RotateSelection.canceled += instance.OnRotateSelection;
                @ShiftSelectionForward.started += instance.OnShiftSelectionForward;
                @ShiftSelectionForward.performed += instance.OnShiftSelectionForward;
                @ShiftSelectionForward.canceled += instance.OnShiftSelectionForward;
                @ShiftSelectionBackward.started += instance.OnShiftSelectionBackward;
                @ShiftSelectionBackward.performed += instance.OnShiftSelectionBackward;
                @ShiftSelectionBackward.canceled += instance.OnShiftSelectionBackward;
            }
        }
    }
    public SelectionActions @Selection => new SelectionActions(this);

    // UI Mode
    private readonly InputActionMap m_UIMode;
    private IUIModeActions m_UIModeActionsCallbackInterface;
    private readonly InputAction m_UIMode_ToggleUIMode;
    public struct UIModeActions
    {
        private @CMInput m_Wrapper;
        public UIModeActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleUIMode => m_Wrapper.m_UIMode_ToggleUIMode;
        public InputActionMap Get() { return m_Wrapper.m_UIMode; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UIModeActions set) { return set.Get(); }
        public void SetCallbacks(IUIModeActions instance)
        {
            if (m_Wrapper.m_UIModeActionsCallbackInterface != null)
            {
                @ToggleUIMode.started -= m_Wrapper.m_UIModeActionsCallbackInterface.OnToggleUIMode;
                @ToggleUIMode.performed -= m_Wrapper.m_UIModeActionsCallbackInterface.OnToggleUIMode;
                @ToggleUIMode.canceled -= m_Wrapper.m_UIModeActionsCallbackInterface.OnToggleUIMode;
            }
            m_Wrapper.m_UIModeActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleUIMode.started += instance.OnToggleUIMode;
                @ToggleUIMode.performed += instance.OnToggleUIMode;
                @ToggleUIMode.canceled += instance.OnToggleUIMode;
            }
        }
    }
    public UIModeActions @UIMode => new UIModeActions(this);

    // Song Speed
    private readonly InputActionMap m_SongSpeed;
    private ISongSpeedActions m_SongSpeedActionsCallbackInterface;
    private readonly InputAction m_SongSpeed_DecreaseSongSpeed;
    private readonly InputAction m_SongSpeed_IncreaseSongSpeed;
    public struct SongSpeedActions
    {
        private @CMInput m_Wrapper;
        public SongSpeedActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @DecreaseSongSpeed => m_Wrapper.m_SongSpeed_DecreaseSongSpeed;
        public InputAction @IncreaseSongSpeed => m_Wrapper.m_SongSpeed_IncreaseSongSpeed;
        public InputActionMap Get() { return m_Wrapper.m_SongSpeed; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SongSpeedActions set) { return set.Get(); }
        public void SetCallbacks(ISongSpeedActions instance)
        {
            if (m_Wrapper.m_SongSpeedActionsCallbackInterface != null)
            {
                @DecreaseSongSpeed.started -= m_Wrapper.m_SongSpeedActionsCallbackInterface.OnDecreaseSongSpeed;
                @DecreaseSongSpeed.performed -= m_Wrapper.m_SongSpeedActionsCallbackInterface.OnDecreaseSongSpeed;
                @DecreaseSongSpeed.canceled -= m_Wrapper.m_SongSpeedActionsCallbackInterface.OnDecreaseSongSpeed;
                @IncreaseSongSpeed.started -= m_Wrapper.m_SongSpeedActionsCallbackInterface.OnIncreaseSongSpeed;
                @IncreaseSongSpeed.performed -= m_Wrapper.m_SongSpeedActionsCallbackInterface.OnIncreaseSongSpeed;
                @IncreaseSongSpeed.canceled -= m_Wrapper.m_SongSpeedActionsCallbackInterface.OnIncreaseSongSpeed;
            }
            m_Wrapper.m_SongSpeedActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DecreaseSongSpeed.started += instance.OnDecreaseSongSpeed;
                @DecreaseSongSpeed.performed += instance.OnDecreaseSongSpeed;
                @DecreaseSongSpeed.canceled += instance.OnDecreaseSongSpeed;
                @IncreaseSongSpeed.started += instance.OnIncreaseSongSpeed;
                @IncreaseSongSpeed.performed += instance.OnIncreaseSongSpeed;
                @IncreaseSongSpeed.canceled += instance.OnIncreaseSongSpeed;
            }
        }
    }
    public SongSpeedActions @SongSpeed => new SongSpeedActions(this);

    // MenusExtended
    private readonly InputActionMap m_MenusExtended;
    private IMenusExtendedActions m_MenusExtendedActionsCallbackInterface;
    private readonly InputAction m_MenusExtended_Tab;
    private readonly InputAction m_MenusExtended_LeaveMenu;
    public struct MenusExtendedActions
    {
        private @CMInput m_Wrapper;
        public MenusExtendedActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tab => m_Wrapper.m_MenusExtended_Tab;
        public InputAction @LeaveMenu => m_Wrapper.m_MenusExtended_LeaveMenu;
        public InputActionMap Get() { return m_Wrapper.m_MenusExtended; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenusExtendedActions set) { return set.Get(); }
        public void SetCallbacks(IMenusExtendedActions instance)
        {
            if (m_Wrapper.m_MenusExtendedActionsCallbackInterface != null)
            {
                @Tab.started -= m_Wrapper.m_MenusExtendedActionsCallbackInterface.OnTab;
                @Tab.performed -= m_Wrapper.m_MenusExtendedActionsCallbackInterface.OnTab;
                @Tab.canceled -= m_Wrapper.m_MenusExtendedActionsCallbackInterface.OnTab;
                @LeaveMenu.started -= m_Wrapper.m_MenusExtendedActionsCallbackInterface.OnLeaveMenu;
                @LeaveMenu.performed -= m_Wrapper.m_MenusExtendedActionsCallbackInterface.OnLeaveMenu;
                @LeaveMenu.canceled -= m_Wrapper.m_MenusExtendedActionsCallbackInterface.OnLeaveMenu;
            }
            m_Wrapper.m_MenusExtendedActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tab.started += instance.OnTab;
                @Tab.performed += instance.OnTab;
                @Tab.canceled += instance.OnTab;
                @LeaveMenu.started += instance.OnLeaveMenu;
                @LeaveMenu.performed += instance.OnLeaveMenu;
                @LeaveMenu.canceled += instance.OnLeaveMenu;
            }
        }
    }
    public MenusExtendedActions @MenusExtended => new MenusExtendedActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_ToggleDebugConsole;
    public struct DebugActions
    {
        private @CMInput m_Wrapper;
        public DebugActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleDebugConsole => m_Wrapper.m_Debug_ToggleDebugConsole;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @ToggleDebugConsole.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnToggleDebugConsole;
                @ToggleDebugConsole.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnToggleDebugConsole;
                @ToggleDebugConsole.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnToggleDebugConsole;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleDebugConsole.started += instance.OnToggleDebugConsole;
                @ToggleDebugConsole.performed += instance.OnToggleDebugConsole;
                @ToggleDebugConsole.canceled += instance.OnToggleDebugConsole;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);

    // Audio
    private readonly InputActionMap m_Audio;
    private IAudioActions m_AudioActionsCallbackInterface;
    private readonly InputAction m_Audio_ToggleHitsoundMute;
    public struct AudioActions
    {
        private @CMInput m_Wrapper;
        public AudioActions(@CMInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @ToggleHitsoundMute => m_Wrapper.m_Audio_ToggleHitsoundMute;
        public InputActionMap Get() { return m_Wrapper.m_Audio; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AudioActions set) { return set.Get(); }
        public void SetCallbacks(IAudioActions instance)
        {
            if (m_Wrapper.m_AudioActionsCallbackInterface != null)
            {
                @ToggleHitsoundMute.started -= m_Wrapper.m_AudioActionsCallbackInterface.OnToggleHitsoundMute;
                @ToggleHitsoundMute.performed -= m_Wrapper.m_AudioActionsCallbackInterface.OnToggleHitsoundMute;
                @ToggleHitsoundMute.canceled -= m_Wrapper.m_AudioActionsCallbackInterface.OnToggleHitsoundMute;
            }
            m_Wrapper.m_AudioActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ToggleHitsoundMute.started += instance.OnToggleHitsoundMute;
                @ToggleHitsoundMute.performed += instance.OnToggleHitsoundMute;
                @ToggleHitsoundMute.canceled += instance.OnToggleHitsoundMute;
            }
        }
    }
    public AudioActions @Audio => new AudioActions(this);
    private int m_ChroMapperDefaultSchemeIndex = -1;
    public InputControlScheme ChroMapperDefaultScheme
    {
        get
        {
            if (m_ChroMapperDefaultSchemeIndex == -1) m_ChroMapperDefaultSchemeIndex = asset.FindControlSchemeIndex("ChroMapper Default");
            return asset.controlSchemes[m_ChroMapperDefaultSchemeIndex];
        }
    }
    public interface ICameraActions
    {
        void OnHoldtoMoveCamera(InputAction.CallbackContext context);
        void OnMoveCamera(InputAction.CallbackContext context);
        void OnRotateCamera(InputAction.CallbackContext context);
        void OnElevateCamera(InputAction.CallbackContext context);
        void OnToggleFullscreen(InputAction.CallbackContext context);
        void OnLocation1(InputAction.CallbackContext context);
        void OnLocation2(InputAction.CallbackContext context);
        void OnLocation3(InputAction.CallbackContext context);
        void OnLocation4(InputAction.CallbackContext context);
        void OnSecondSetModifier(InputAction.CallbackContext context);
        void OnOverwriteLocationModifier(InputAction.CallbackContext context);
    }
    public interface IUtilsActions
    {
        void OnControlModifier(InputAction.CallbackContext context);
        void OnAltModifier(InputAction.CallbackContext context);
        void OnShiftModifier(InputAction.CallbackContext context);
        void OnMouseMovement(InputAction.CallbackContext context);
    }
    public interface IActionsActions
    {
        void OnUndoMethod1(InputAction.CallbackContext context);
        void OnUndoMethod2(InputAction.CallbackContext context);
        void OnRedoMethod1(InputAction.CallbackContext context);
        void OnRedoMethod2(InputAction.CallbackContext context);
    }
    public interface IPlacementControllersActions
    {
        void OnPlaceObject(InputAction.CallbackContext context);
        void OnInitiateClickandDrag(InputAction.CallbackContext context);
        void OnInitiateClickandDragatTime(InputAction.CallbackContext context);
        void OnMousePositionUpdate(InputAction.CallbackContext context);
        void OnCancelPlacement(InputAction.CallbackContext context);
    }
    public interface IWorkflowsActions
    {
        void OnToggleNoteColor(InputAction.CallbackContext context);
        void OnPlaceRedNote(InputAction.CallbackContext context);
        void OnPlaceBlueNote(InputAction.CallbackContext context);
        void OnToggleDeleteTool(InputAction.CallbackContext context);
        void OnMirrorHorizontally(InputAction.CallbackContext context);
        void OnMirrorVertically(InputAction.CallbackContext context);
        void OnMirrorinTime(InputAction.CallbackContext context);
        void OnMirrorColoursOnly(InputAction.CallbackContext context);
        void OnSwapCursorInterval(InputAction.CallbackContext context);
    }
    public interface ISavingActions
    {
        void OnSave(InputAction.CallbackContext context);
    }
    public interface IBookmarksActions
    {
        void OnCreateNewBookmark(InputAction.CallbackContext context);
        void OnNextBookmark(InputAction.CallbackContext context);
        void OnPreviousBookmark(InputAction.CallbackContext context);
        void OnColorBookmarkModifier(InputAction.CallbackContext context);
    }
    public interface IRefreshMapActions
    {
        void OnRefreshMap(InputAction.CallbackContext context);
    }
    public interface IPlaybackActions
    {
        void OnTogglePlaying(InputAction.CallbackContext context);
        void OnResetTime(InputAction.CallbackContext context);
    }
    public interface ITimelineActions
    {
        void OnChangeTimeandPrecision(InputAction.CallbackContext context);
        void OnChangePrecisionModifier(InputAction.CallbackContext context);
        void OnPreciseSnapModification(InputAction.CallbackContext context);
    }
    public interface IEditorScaleActions
    {
        void OnDecreaseEditorScale(InputAction.CallbackContext context);
        void OnIncreaseEditorScale(InputAction.CallbackContext context);
    }
    public interface IBeatmapObjectsActions
    {
        void OnSelectObjects(InputAction.CallbackContext context);
        void OnMassSelectModifier(InputAction.CallbackContext context);
        void OnQuickDelete(InputAction.CallbackContext context);
        void OnDeleteTool(InputAction.CallbackContext context);
        void OnMousePositionUpdate(InputAction.CallbackContext context);
        void OnJumptoObjectTime(InputAction.CallbackContext context);
    }
    public interface INoteObjectsActions
    {
        void OnInvertNoteColors(InputAction.CallbackContext context);
        void OnQuickDirectionModifier(InputAction.CallbackContext context);
    }
    public interface IBPMChangeObjectsActions
    {
        void OnReplaceBPM(InputAction.CallbackContext context);
        void OnTweakBPMValue(InputAction.CallbackContext context);
    }
    public interface IBoxSelectActions
    {
        void OnActivateBoxSelect(InputAction.CallbackContext context);
    }
    public interface IBPMTapperActions
    {
        void OnToggleBPMTapper(InputAction.CallbackContext context);
    }
    public interface IPauseMenuActions
    {
        void OnPauseEditor(InputAction.CallbackContext context);
    }
    public interface ISelectionActions
    {
        void OnDeselectAll(InputAction.CallbackContext context);
        void OnDeleteObjects(InputAction.CallbackContext context);
        void OnCut(InputAction.CallbackContext context);
        void OnPaste(InputAction.CallbackContext context);
        void OnCopy(InputAction.CallbackContext context);
        void OnOverwritePaste(InputAction.CallbackContext context);
        void OnRotateSelection(InputAction.CallbackContext context);
        void OnShiftSelectionForward(InputAction.CallbackContext context);
        void OnShiftSelectionBackward(InputAction.CallbackContext context);
    }
    public interface IUIModeActions
    {
        void OnToggleUIMode(InputAction.CallbackContext context);
    }
    public interface ISongSpeedActions
    {
        void OnDecreaseSongSpeed(InputAction.CallbackContext context);
        void OnIncreaseSongSpeed(InputAction.CallbackContext context);
    }
    public interface IMenusExtendedActions
    {
        void OnTab(InputAction.CallbackContext context);
        void OnLeaveMenu(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnToggleDebugConsole(InputAction.CallbackContext context);
    }
    public interface IAudioActions
    {
        void OnToggleHitsoundMute(InputAction.CallbackContext context);
    }
}
