using Marmary.Utils.Runtime.Events;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

namespace Marmary.Utils.Runtime.UI
{
    namespace Marmary.Libraries.UI
    {
        /// <summary>
        ///     Extends the functionality of the <see cref="InputSystemUIInputModule" /> to provide
        ///     custom UI navigation and interaction logic within the Marmary framework.
        /// </summary>
        /// <remarks>
        ///     This input module is designed to handle custom submit button behavior, axis-based fallback selection,
        ///     and additional navigation adjustments for UI systems. It overrides the base input processing behavior
        ///     to allow for a more tailored control scheme, including:
        ///     - Reading navigation input prior to internal processing.
        ///     - Handling custom button press and release events.
        ///     - Resetting the selected GameObject on cancel input.
        ///     - Applying fallback selection logic when no UI element is currently selected.
        ///     Note: Ensure that this input module is assigned to the Event System for it to function correctly.
        /// </remarks>
        public class MStandaloneInputModule : InputSystemUIInputModule
        {
            #region Serialized Fields

            /// <summary>
            ///     An instance of a class implementing the IDefaultSelectable interface used to manage
            ///     the default selectable UI element when no other element is currently selected.
            /// </summary>
            [SerializeReference] private IDefaultSelectable menuManager;

            /// <summary>
            ///     Dead zone threshold for axis input to trigger navigation.
            /// </summary>
            [SerializeField] private float deadZone = 0.2f;

            #endregion

            #region Fields

            /// <summary>
            ///     Stores the last selected GameObject when the submit button is pressed.
            /// </summary>
            private GameObject _lastSelected;

            #endregion

            #region Methods

            /// <summary>
            ///     Processes input for UI navigation and interaction.
            ///     Handles custom submit button logic and axis-based fallback selection.
            /// </summary>
            public override void Process()
            {
                var submitAction = submit?.action;
                var cancelAction = cancel?.action;
                var moveAction = move?.action;

                // --- Leer input de navegación ANTES del procesamiento interno ---
                var moveInput = moveAction != null ? moveAction.ReadValue<Vector2>() : Vector2.zero;
                var h = moveInput.x;
                var v = moveInput.y;

                // --- Botón Down/Up personalizado ---
                if (submitAction != null)
                {
                    if (submitAction.WasPressedThisFrame())
                    {
                        if (eventSystem.currentSelectedGameObject != null)
                            _lastSelected = eventSystem.currentSelectedGameObject;
                    }
                    else if (submitAction.WasReleasedThisFrame())
                    {
                        if (_lastSelected != null)
                            ExecuteEvents.Execute(
                                _lastSelected,
                                new PointerEventData(EventSystem.current),
                                MExecuteEvents.UnpressedHandler
                            );
                    }
                }

                if (cancelAction != null && cancelAction.WasPressedThisFrame())
                    eventSystem.SetSelectedGameObject(null);

                // --- Ejecutar navegación interna ---
                base.Process();

                // --- Aplicar fallback sólo si sigue sin haber selección ---
                if (eventSystem.currentSelectedGameObject == null && menuManager != null)
                {
                    if (h > deadZone) menuManager.SetDefaultSelectable(Position.Right);
                    else if (h < -deadZone) menuManager.SetDefaultSelectable(Position.Left);
                    else if (v > deadZone) menuManager.SetDefaultSelectable(Position.Top);
                    else if (v < -deadZone) menuManager.SetDefaultSelectable(Position.Bottom);
                }
            }

            #endregion
        }
    }
}