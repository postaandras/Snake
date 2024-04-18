using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource SFXSource;

    public AudioClip LeftSound;
    public AudioClip RidhtSound;
    public AudioClip UpSound;
    public AudioClip DownSound;
    public AudioClip DeathSound;
    public AudioClip EatSound;

    // Start is called before the first frame update
    void Awake()
    {
        MovementController.onGameOver += MovementController_onGameOver;
        MovementController.onApplePick += MovementController_onApplePick;
        InputController.onMove += InputController_onMove;
    }

    private void OnDestroy()
    {
        MovementController.onGameOver -= MovementController_onGameOver;
        MovementController.onApplePick -= MovementController_onApplePick;
        InputController.onMove -= InputController_onMove;
    }

    private void MovementController_onGameOver(object sender, System.EventArgs e)
    {
        PlaySFX(DeathSound);
    }

    private void MovementController_onApplePick(object sender, MovementController.OnApplePick e)
    {
        PlaySFX(EatSound);
    }

    private void InputController_onMove(object sender, InputController.OnMove e)
    {
        switch (e.MoveDirection)
        {
            case MoveDirection.UP:
                PlaySFX(UpSound);
                break;
            case MoveDirection.DOWN:
                PlaySFX(DownSound);
                break;
            case MoveDirection.LEFT:
                PlaySFX(LeftSound);
                break;
            case MoveDirection.RIGHT:
                PlaySFX(RidhtSound);
                break;
        }
    }


    private void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
