using System.Diagnostics;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject[] bulletPrefabs;         // Array para os prefabs de tiro
    public float shootInterval = 0.5f;         // Intervalo entre disparos em segundos
    public int sampleSize = 1024;              // Tamanho da amostra de dados
    public FFTWindow fftWindow = FFTWindow.BlackmanHarris;  // Tipo de janela para FFT

    private float[] spectrumData;
    private float nextShootTime;

    void Start()
    {
        spectrumData = new float[sampleSize];
        nextShootTime = Time.time;  // Inicializa o tempo do próximo disparo
    }

    void Update()
    {
        // Obtém o espectro de frequências do áudio
        audioSource.GetSpectrumData(spectrumData, 0, fftWindow);

        // Determina a frequência dominante
        float maxFrequency = 0f;
        int maxIndex = 0;

        for (int i = 0; i < sampleSize; i++)
        {
            if (spectrumData[i] > maxFrequency)
            {
                maxFrequency = spectrumData[i];
                maxIndex = i;
            }
        }

        // Converte o índice da amostra na frequência correspondente
        float freqN = (float)maxIndex / sampleSize;  // Normaliza o índice
        float frequency = freqN * AudioSettings.outputSampleRate / 2;  // Calcula a frequência em Hz

        UnityEngine.Debug.Log("Frequência dominante: " + frequency + " Hz");

        // Verifica se é hora de disparar
        if (Time.time >= nextShootTime)
        {
            // Determina a altura do tiro
            Vector3 position1;
            Vector3 position2;
            if (frequency > 1500)
            {
                position1 = new Vector3(10, -2, 0);
                position2 = new Vector3(10, 2, 0);
            }
            else if (frequency >= 350 && frequency <= 1500)
            {
                position1 = new Vector3(10, 0, 0);
                position2 = new Vector3(10, 2, 0);
            }
            else
            {
                position1 = new Vector3(10, 0, 0);
                position2 = new Vector3(10, -2, 0);
            }

            // Escolhe um prefab aleatório
            GameObject bulletPrefab1 = bulletPrefabs[UnityEngine.Random.Range(0, bulletPrefabs.Length)];
            GameObject bulletPrefab2 = bulletPrefabs[UnityEngine.Random.Range(0, bulletPrefabs.Length)];

            // Spawna os tiros
            SpawnBullet1(position1, bulletPrefab1);
            SpawnBullet2(position2, bulletPrefab2);

            // Atualiza o tempo do próximo disparo
            nextShootTime = Time.time + shootInterval;
        }
    }

    // Método para spawnar o tiro
    private void SpawnBullet1(Vector3 position1, GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab, position1, Quaternion.identity);
    }

    private void SpawnBullet2(Vector3 position2, GameObject bulletPrefab)
    {
        Instantiate(bulletPrefab, position2, Quaternion.identity);
    }
}
