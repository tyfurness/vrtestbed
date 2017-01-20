namespace VRTK.Examples
{
    using System.Collections;
    using UnityEngine;

    public class Gun : VRTK_InteractableObject
    {
        private GameObject bullet;
        private float bulletSpeed = 2000f;
        private float bulletLife = 5f;

        [SerializeField]
        private Animator gunShot;

        public override void StartUsing(GameObject usingObject)
        {
            base.StartUsing(usingObject);
            gunShot.SetTrigger("hasShot");
            Fire();
        }

        protected void Start()
        {
            bullet = transform.Find("Bullet").gameObject;
            bullet.SetActive(false);
        }

        private void Fire()
        {
            GameObject bulletClone = Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(-bullet.transform.forward * bulletSpeed);

            Destroy(bulletClone, bulletLife);
        }

        public void ANIM_ONSHOTCOMPLETE()
        {
            gunShot.ResetTrigger("hasShot");
        }
    }
}