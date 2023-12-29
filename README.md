## 프로젝트 소개
죽음의 신 사신 '데스'는 자신의 부하들이 자기를 배신하고 자기 자리를 노리고 덤비는 부하들을 정신교육하는 게임 
### 개발 환경
- Unity 2022.3.2f1
- Visual Studio Community

## 주요 기능
#### 게임 시작
-게임 조작
 - 이동 : 좌우방향키
 - 점프 : 스페이스바
 - 공격 : Z(근거리 공격)
- 캐릭터
 1. 주인공 캐릭터는 플레이어의 조작에 따라 움직입니다.
 2. 캐릭터는 좌우 방향키로 움직입니다. 좌우 방향키에 따라 쳐다보는 방향이 달라집니다. 
 3. 공격 모션을 취하고 있을 땐 다른 행동은 할 수 없습니다. 
- 몬스터 
 1. 몬스터는 10hp 를 가지고 있다. 
 2. 10대를 맞으면 죽는데 크기가 작아진 몬스터는 내 동료가 되어 따라다닌다.
    
    ![image](https://github.com/b0ssTiger/Sickle/assets/120788949/ce162796-e9a5-4b42-b286-336c5c632292)

(몬스터 모션 애니메이션은 자체제작, 공격모션이 없었다.. 몬스터 공격 스타일은 몬스터 패턴공격 피한 후, 공격할 시간이 주어지는 방식 생각 / 코루틴 사용 가능한가? )
- UI
 1. 게임 시작 화면
    
    ![image](https://github.com/b0ssTiger/Sickle/assets/120788949/b2bed0cf-8714-48ce-a283-0fabd9728d63)


(진행예정)

3. 캐릭터 조작키 튜토리얼 인터페이스 만들기 
4. 옵션 (사운드,일시정지,세이브파일,)
- 사운드(아직 진행 못함)
 1. 게임 배경음악 넣어주기
 2. 캐릭터 행동시 효과음 넣어주기
