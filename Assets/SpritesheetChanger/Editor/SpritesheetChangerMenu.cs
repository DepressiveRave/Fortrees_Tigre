using UnityEditor;
using SpritesheetChanger.Copy;
using SpritesheetChanger.Setter;

public class SpritesheetChangerMenu : Editor
{
    [MenuItem("Spritesheet Changer/Sprite sheet Pivot Setter")]
    public static void OpenPivotModifierWindow()
    {
        SpritesheetPivotSetterEditor.ShowWindow();
    }

    [MenuItem("Spritesheet Changer/Sprite sheet Copy")]
    public static void OpenSpritesheetCopyWindow()
    {
        SpritesheetCopyEditor.ShowWindow();
    }

    [MenuItem("Spritesheet Changer/Sprite Copy")]
    public static void OpenSpriteWindow()
    {
        SpriteCopy.ShowWindow();
    }
}
