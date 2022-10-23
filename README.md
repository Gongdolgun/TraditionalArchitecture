![header](https://capsule-render.vercel.app/api?type=waving&color=auto&height=200&section=header&text=Traditional_Architecture&fontSize=60)

# Traditional Architecture

### [프로젝트 기간]
2021.11 ~ 2022.01

### [기술 스택]
<img src="https://img.shields.io/badge/Unity-000000?style=flat-square&logo=Unity&logoColor=white"/>  <img src="https://img.shields.io/badge/C Sharp-239120?style=flat-square&logo=C Sharp&logoColor=white"/>  <img src="https://img.shields.io/badge/MAXSTAR-00A98F?style=flat-square&logo=Monzo&logoColor=white"/>  <img src="https://img.shields.io/badge/Synology-B5B5B6?style=flat-square&logo=Synology&logoColor=white"/>

### [아키텍처]
<img width="80%" src="https://user-images.githubusercontent.com/90584581/197387520-19b892ca-65f2-421d-8a24-f7e5185ecfd3.png"/>

### [프로젝트 내용]
Unity로 제작된 한국 전통건축 관련 국가 사업입니다.
영상과 간단한 게임 및 AR 컨텐츠로 여러가지 전통건축 관련 지식을 습득할 수 있는 프로젝트입니다.

<img width="40%" src="https://user-images.githubusercontent.com/90584581/196897583-34eea8bc-2a72-42fa-a415-78c7281771d9.jpg"/>  <img width="40%" src="https://user-images.githubusercontent.com/90584581/197323543-7abdee34-07c4-4a4c-804c-1e66ea54121c.png"/>
<img width="40%" src="https://user-images.githubusercontent.com/90584581/196897598-ede2a9fb-5aa6-4556-951a-8e6e9782af10.jpg"/>  <img width="40%" src="https://user-images.githubusercontent.com/90584581/196897601-632103d2-4850-4030-9c56-73eb8f73a1f0.jpg"/>

### [프로젝트 투입 인원]
개발자 2, 디자이너 1

### [나의 역할]
- 프로젝트 기획
- Video Player 제작
- UI 배치 및 기능 구현
- 색칠 게임 기능 구현
- 애니메이션 및 비주얼 이펙트 제작
- AR 컨텐츠 기능 구현

### [핵심 코드]
이 프로젝트는 3개의 Scene으로 나눠서 진행됩니다.\
Video Scene, AR Scene, Painting Scene 이렇게 3가지로 나뉩니다.

#### Video Scene의 핵심 코드
persistantDataPath의 URL에 따라 해당 비디오파일을 읽어 재생합니다.

    ```
    public void VideoPlay(int index)
    {
        VP.url = Application.persistentDataPath + VideoURL[index];
        if (System.IO.File.Exists(VP.url))
        { 
            UIcanvas.SetActive(false);
            Videocanvas.SetActive(true);
            slider.clipIndex = index;
            VP.frame = 0;
            VP.Play();
            VC.PlayBtnPressed();
        }
        else
        {
            UIcanvas.SetActive(false);
            VideoExists.SetActive(true);
        }
    }
    ```
    
#### AR SCene의 핵심 코드
AR에서 핵심은 트래킹과 초기화라고 생각합니다. 이 코드는 트래킹 되었을 때와 안되었을 때 초기화 되는 코드입니다.

    ```
    public class ImageTrackableBehaviour : AbstractImageTrackableBehaviour
    {
		public override void OnTrackSuccess(string id, string name, Matrix4x4 poseMatrix)
        {
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
			// Enable renderers
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = true;
			}

			// Enable colliders
			foreach (Collider component in colliderComponents)
			{
				component.enabled = true;
			}

			transform.position = MatrixUtils.PositionFromMatrix(poseMatrix);
			transform.rotation = MatrixUtils.QuaternionFromMatrix(poseMatrix);

			Debug.Log(transform.position);
        }

        public override void OnTrackFail()
        {
			Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
			Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

			// Disable renderer
			foreach (Renderer component in rendererComponents)
			{
				component.enabled = false;
			}

			// Disable collider
			foreach (Collider component in colliderComponents)
			{
				component.enabled = false;
			}
        }
    }
    ```

![Footer](https://capsule-render.vercel.app/api?type=waving&color=auto&height=200&section=footer)
