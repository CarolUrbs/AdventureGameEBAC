using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using AnimationManager;
namespace Enemy
{
public class EnemyBase : MonoBehaviour
{
        public float startLife=10f;
        public float _currentLife;
        [Header(" Animation")]
        [SerializeField]public AnimationBase animationBase;
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startwithBornAnimation=true;

        private void Awake()
        {
         Init();
        }
        protected void ResetLife()
        {
            _currentLife = startLife;

        }
        protected virtual void Init()
        {
            ResetLife();
            if (startwithBornAnimation)
            BornAnimation();
        }
        protected virtual void Kill()

        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            Destroy(gameObject,3f);
            PlayAnimationByTrigger (AnimationType.DEATH);
        }

        public void OnDamage(float f)
        {
            _currentLife = -f;
            if(_currentLife<=0)
            {
                Kill();
            }
        }
        #region ANIMATION
        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            animationBase.PlayAnimationByTrigger(animationType);
        }
        #endregion
        private void Update()
        {
            #region TESTE (�REA COMENTADA
            /*  */
            if (Input.GetKeyDown(KeyCode.T))
              {
                  OnDamage(10f);
                  Debug.Log(_currentLife);
              }
            #endregion
        }
    }

}

