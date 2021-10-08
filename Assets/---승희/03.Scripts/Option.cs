using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Option : MonoBehaviour
{
    public static FullScreenMode screenMode;
    public Toggle fullscreenToggle;

    public TMPro.TMP_Dropdown shadowDropdown;               //TextMesh Pro를 이용한 Dropdown
    List<string> shadowOptions = new List<string>();        //그림자 옵션 문자열을 담을 List

    public TMPro.TMP_Dropdown resolutionDropdown;           //TextMesh Pro를 이용한 Dropdown
    public static List<Resolution> resolutions = new List<Resolution>();  //해상도 문자열을 담을 List

    public static int resolutionNum, shadowNum;

    void Start()
    {
        InitOption();
    }

    //
    //확인 버튼 클릭
    public static void ChangeOption()
    {
        //그림자 변경
        LightManager.dLight.SetShadowOption(shadowNum);

        //화면 변경 (해상도, 전체 화면||창 화면)
        Screen.SetResolution(
                                resolutions[resolutionNum].width,
                                resolutions[resolutionNum].height,
                                screenMode
                            );
    }

    //
    // [ 옵션 초기화 ]
    public void InitOption()
    {
        // 그림자 옵션
        LightManager.dLight.GetComponent<Light>().shadows = LightShadows.Soft;
        shadowDropdown.options.Clear();                     //그림자 Dropdown 안의 Option을 비워주기

        shadowOptions.Add("그림자 없음");
        shadowOptions.Add("약한 그림자");
        shadowOptions.Add("강한 그림자");

        for (int i = 0; i < shadowOptions.Count; i++)       //그림자 Dropdown 안의 Option 설정
        {
            TMP_Dropdown.OptionData shaOption = new TMP_Dropdown.OptionData();
            shaOption.text = shadowOptions[i];
            shadowDropdown.options.Add(shaOption);
        }
        shadowDropdown.RefreshShownValue();


        // 전체 화면||창 화면 : Toggle
        fullscreenToggle.isOn =
            Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;


        // 화면 해상도 : Dropdown
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRate >= 60)    //화면재생빈도가 60 이상인 값만 List에 넣기
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }
        resolutionDropdown.options.Clear();                 //해상도 Dropdown 안의 Option을 비워주기

        int optionNum = 0;

        for (int i = 0; i < resolutions.Count; i++)         //해상도 Dropdown 안의 Option 설정
        {
            TMP_Dropdown.OptionData resOption = new TMP_Dropdown.OptionData();
            resOption.text = resolutions[i].width + " X " + resolutions[i].height + " " + resolutions[i].refreshRate;
            resolutionDropdown.options.Add(resOption);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)         //맨처음 자신의 화면에 맞는 해상도로 기본 설정
            {
                resolutionDropdown.value = optionNum;
            }

            optionNum++;
        }

        resolutionDropdown.RefreshShownValue();
    }

    //
    // [ 배경음악 ]
    public void SetBgmVolume(float volume)
    {
        SoundManager.instance.mixer.SetFloat("BgmVolume", Mathf.Log10(volume) * 20);
    }

    //
    // [ 효과음 ]
    public void SetSfxVolume(float volume)
    {
        SoundManager.instance.mixer.SetFloat("SfxVolume", Mathf.Log10(volume) * 20);
    }

    //
    // [ 그림자 옵션 ]
    public void ShadowOptionChange(int x)
    {
        shadowNum = x;
    }

    //
    // [ 해상도 ]
    public void ResolutionOptionChange(int x)      //해상도 Dropdown 안 어떤 Option을 선택했는지를 받아온다
    {
        resolutionNum = x;
    }

    //
    // [ 전체 화면||창 화면 ]
    public void IsFullScreen(bool isFull)
    {
        screenMode = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }
}
