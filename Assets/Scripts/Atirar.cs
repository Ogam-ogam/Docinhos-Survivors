using System.Collections;
using UnitySystem;
using Ataque;

public class Atirar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Update()
    {
        StartCoroutine(Atirar());
    }

    IEnumerator Atirar()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.5f);
            _alvo = GameObject.FindWithTag("Inimigo");
    
            if (_alvo == null) return;
    
            GameObject _balaInstanciada = Instantiate(_prefabBala, transform.position, Quaternion.identity);
    
            Vector2 direcao = (_alvo.transform.position - transform.position).normalized;
        
            Bala _scriptBala = _balaInstanciada.GetComponent<Bala>();
            _scriptBala.Inicializar(direcao, _velocidadeBala);
        }
    }
}