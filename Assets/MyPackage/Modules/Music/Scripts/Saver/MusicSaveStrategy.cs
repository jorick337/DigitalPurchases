namespace MyPackage.Modules.Saver
{
    public partial interface SaveStrategy
    {
        void SaveMusicActive(bool active);
        bool LoadMusicActive();

        void SaveSoundsActive(bool active);
        bool LoadSoundsActive();

        void SaveMusicVolume(float value);
        float LoadMusicVolume();

        void SaveSoundsVolume(float value);
        float LoadSoundsVolume();
    }
}