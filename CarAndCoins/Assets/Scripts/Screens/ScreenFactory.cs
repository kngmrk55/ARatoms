namespace Scripts.Screens
{
    using System.Collections.Generic;
    using UnityEngine;
    using System.Linq;

    public enum ScreenType
    {
        SCREEN_MENU,
        SCREEN_GAME,
        SCREEN_ENDGAME
    }

    public class ScreenFactory
    {
        #region Fields

        static Dictionary<ScreenType, AbstractScreen> _screens = new Dictionary<ScreenType, AbstractScreen>();

        #endregion

        #region Register and Unregister Screen

        public void register(AbstractScreen abstactScreen, ScreenType screenType)
        {
            Debug.Assert(abstactScreen != null);

            bool isRegistered = _screens.ContainsKey(screenType);
            Debug.Assert(!isRegistered);
            if(!isRegistered)
                _screens.Add(screenType, abstactScreen);
        }

        public void unregister(ScreenType screenType)
        {
            bool isRegistered = _screens.ContainsKey(screenType);
            Debug.Assert(isRegistered);
            if (isRegistered)
                _screens.Remove(screenType);
        }

        #endregion

        #region Get Screen

        public AbstractScreen getScreen(ScreenType screenType)
        {
            Debug.Assert(_screens != null);
            return _screens[screenType];
        }

        public T getScreen<T> () where T : AbstractScreen
        {
            Debug.Assert(_screens != null);

            T screen = _screens.FirstOrDefault(selectedScreen => selectedScreen is T) as T;

            if (screen == null)
                Debug.Log("Screen not registered");

            return screen;

        }

        public int getRegisteredScreens()
        {
            return _screens.Count;
        }

        #endregion
    }
}
