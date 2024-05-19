
using System.Runtime.Serialization;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Particles : MonoBehaviour
{
    public GameObject _player;
    public GameObject botao;
    public GameObject[] botoes;

    [SerializeField]
    private GameObject _object;

    public void Spawn()
    {
        Instantiate(_object, transform.position, Quaternion.identity);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
    Vector2 contactNormal = other.GetContact(0).normal;

    // Verifica se a normal da colisão está apontando para cima
    if (contactNormal.y > 0)
    {
        if(other.gameObject == _player)
        {
            foreach (GameObject botao in botoes)
            {
             Instantiate(_object, botao.transform.position, Quaternion.identity);
            }
        }
    }
    }
}
