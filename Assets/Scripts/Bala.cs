using UnitySystem;
namespace Ataque

{
    public class Bala : MonoBehaviour
    {
        private Rigidbody2D _rb2D;
        private BoxCollider2D _bc2D;

        void Start()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            _bc2D = GetComponent<BoxCollider2D>();

            Destroy(gameObject, 1.5f);
        }

        public void Inicializar(Vector2 direcao, float velocidade)
        {
            _rb2D.velocity = direcao * velocidade;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Inimigo"))
            {
                Destroy(gameObject);
            }
        }
    }
}
