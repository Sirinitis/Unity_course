using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _prefabsPlatforms;
    [SerializeField] private GameObject _PrefabsFirstPlatform;
    [SerializeField] private Transform _finishPlatform;
    [SerializeField] private Transform _cylinderRoot;
    [SerializeField] private Game _game;
    [SerializeField] private int _minPlatforms;

    private const float _hightLevel = -1.23f;
    private const float _hightFirstLevel = -2.46f;
    private int _platformCount;
    private int _levelIndex;

    private void Awake()
    {
        Generator();
    }

    private void Generator()
    {
        _levelIndex = _game.LevelIndex;
        Random rnd = new Random(_levelIndex);

        _platformCount = RandomRange(rnd, _minPlatforms + _levelIndex, _minPlatforms + _levelIndex + 1);
        for (int i = 0; i < _platformCount; i++)
        {
            int prefabIndex = RandomRange(rnd, 0, _prefabsPlatforms.Length);
            GameObject PrefabPlatform = i == 0 ? _PrefabsFirstPlatform : _prefabsPlatforms[prefabIndex];
            GameObject platform = Instantiate(PrefabPlatform, transform);
            platform.transform.localPosition = PositionCalculationPlatform(i);
            if (i > 0)
                platform.transform.localRotation = Quaternion.Euler(0, RandomRange(rnd, 0, 360), 0);
        }
        _finishPlatform.localPosition = PositionCalculationPlatform(_platformCount);
        _cylinderRoot.localScale = new Vector3(1, (-_hightFirstLevel - _hightLevel * _platformCount) / 2, 1);
    }

    private Vector3 PositionCalculationPlatform(int platformIndex)
    {
        return new Vector3(0, _hightFirstLevel+ _hightLevel * platformIndex, 0);
    }
    private int RandomRange( Random rnd, int min, int maxExclusive)
    {
        int number = rnd.Next();
        int length = maxExclusive - min;
        number %= length;
        return min + number;
    }
    private float RandomRange(Random rnd, float min, float max)
    {
        float t = (float)rnd.NextDouble();
        return Mathf.Lerp(min, max, t);
    }
}
