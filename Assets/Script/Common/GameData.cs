using System;

[Serializable] // 직렬화

public class Data
{
    // 각 챕터의 잠금여부를 저장할 배열
    public int coin = new int();
    public int[] highScore = new int[6];
    public bool[] stageLock = new bool[6];
}
