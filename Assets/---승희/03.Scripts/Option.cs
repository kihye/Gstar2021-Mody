using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class Option : MonoBehaviour
{
    public static FullScreenMode screenMode;
    public Toggle fullscreenToggle;

    //-- Post Processing On/Off --//
    public PostProcessProfile ppProfile;    //Post Processing Profile
    private AmbientOcclusion ambient;
    private Bloom bloom;
    private DepthOfField depth;
    private AutoExposure exposure;
    private Vignette vignette;
    private MotionBlur blur;

    public Toggle ambientT;                  //Ambient Occlusion //한 장면의 각 점이 앰비언트 라이팅(광원)에 얼마나 노출되어 있는지를 계산
    public Toggle bloomT;                    //Bloom             //빛 퍼짐
    public Toggle depthT;                      //Depth Of Field    //피사계 심도    //거리에 따른 초점 조절
    public Toggle exposureT;                 //Auto Exposure     //자동 노출      //자동 빛 조절
    public Toggle vignetteT;                 //Vignette          //비네팅         //외곽부분이 어두워지는 효과
    public Toggle blurT;                     //Motion Blur       //빠르게 움직이는 물체의 뚜렷한 줄무늬

    //-- 옵션 창에서 포스트 프로세싱 토글들을 인게임 옵션창에서만 띄우기 위함 --//
    public static GameObject ppTexts;
    public static GameObject ppToggles;

    public TMPro.TMP_Dropdown shadowDropdown;               //TextMesh Pro를 이용한 Dropdown
    List<string> shadowOptions = new List<string>();        //그림자 옵션 문자열을 담을 List

    public TMPro.TMP_Dropdown resolutionDropdown;           //TextMesh Pro를 이용한 Dropdown
    public static List<Resolution> resolutions = new List<Resolution>();  //해상도 문자열을 담을 List

    public static int resolutionNum, shadowNum;

    private void Awake()
    {
        ppTexts = GameObject.Find("PPs");
        ppToggles = GameObject.Find("PPsToggles");
    }

    void Start()
    {
        InitOption();
    }

    //
    //현재 scene 확인
    public static void CheckNowScene()
    {
        if (SceneManager.GetActiveScene().name == "TitleScene")
        {
            ppTexts.SetActive(false);
            ppToggles.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "MainMapScene")
        {
            ppTexts.SetActive(true);
            ppToggles.SetActive(true);
        }
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

    //
    // [ 포스트 프로세싱 효과 ON/OFF ]
    public void IsAmbient()
    {
        ppProfile = GameObject.Find("PostProcessVolume").GetComponent<PostProcessVolume>().profile;
        ppProfile.TryGetSettings<AmbientOcclusion>(out ambient);
        //ambient.enabled.value = toggle ? true : false;

        if (ambientT.isOn)
        {
            ambient.enabled.value = true;
        }
        else
        {
            ambient.enabled.value = false;
        }

        Debug.Log("ambient 효과 : " + ambient.enabled.value);
    }

    public void IsBloom(bool toggle)
    {
        ppProfile = GameObject.Find("PostProcessVolume").GetComponent<PostProcessVolume>().profile;
        ppProfile.TryGetSettings<Bloom>(out bloom);
        //bloom.enabled.value = toggle ? true : false;

        if (bloomT.isOn)
        {
            bloom.enabled.value = true;
        }
        else
        {
            bloom.enabled.value = false;
        }

        Debug.Log("bloom 효과 : " + bloom.enabled.value);
    }

    public void IsDOF(bool toggle)
    {
        ppProfile = GameObject.Find("PostProcessVolume").GetComponent<PostProcessVolume>().profile;
        ppProfile.TryGetSettings<DepthOfField>(out depth);
        //depth.enabled.value = toggle ? true : false;

        if (depthT.isOn)
        {
            depth.enabled.value = true;
        }
        else
        {
            depth.enabled.value = false;
        }

        Debug.Log("depth 효과 : " + depth.enabled.value);
    }

    public void IsExposure(bool toggle)
    {
        ppProfile = GameObject.Find("PostProcessVolume").GetComponent<PostProcessVolume>().profile;
        ppProfile.TryGetSettings<AutoExposure>(out exposure);
        //exposure.enabled.value = toggle ? true : false;

        if (exposureT.isOn)
        {
            exposure.enabled.value = true;
        }
        else
        {
            exposure.enabled.value = false;
        }

        Debug.Log("exposure 효과 : " + exposure.enabled.value);
    }

    public void IsVignette(bool toggle)
    {
        ppProfile = GameObject.Find("PostProcessVolume").GetComponent<PostProcessVolume>().profile;
        ppProfile.TryGetSettings<Vignette>(out vignette);
        //vignette.enabled.value = toggle ? true : false;

        if (vignetteT.isOn)
        {
            vignette.enabled.value = true;
        }
        else
        {
            vignette.enabled.value = false;
        }

        Debug.Log("vignette 효과 : " + vignette.enabled.value);
    }

    public void IsBlur(bool toggle)
    {
        ppProfile = GameObject.Find("PostProcessVolume").GetComponent<PostProcessVolume>().profile;
        ppProfile.TryGetSettings<MotionBlur>(out blur);
        //blur.enabled.value = toggle ? true : false;

        if (blurT.isOn)
        {
            blur.enabled.value = true;
        }
        else
        {
            blur.enabled.value = false;
        }

        Debug.Log("blur 효과 : " + blur.enabled.value);
    }
}
