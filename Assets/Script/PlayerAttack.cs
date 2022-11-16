using UnityEngine;

namespace Script
{
    public class PlayerAttack : MonoBehaviour
    {
        
        // Start is called before the first frame update
        private bool _attacked = false;
        
        void Start()
        {
            NewAttack();
        }

        // Update is called once per frame
        void Update()
        {
        }
        public void NewAttack()
        {
            _attacked = false;
        }

        public void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("enemy") && _attacked == false)
            {
                _attacked = true;
                //enemy -HP
            }

        }
    }
}
