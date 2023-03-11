using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParemeterPlayer : MonoBehaviour
{
    public int health = 100; //Máu ban đầu
    public int experience = 0; //Kinh nghiệm ban đầu
    public int speed = 5; //Tốc độ ban đầu
    public int level = 1; //Cấp độ ban đầu

    private const int MAX_EXPERIENCE = 100; //Giới hạn kinh nghiệm để tăng cấp

    // Hàm cập nhật thông số khi nhận EXP
    public void GainExperience(int exp)
    {
        experience += exp; //Cộng thêm EXP mới vào tổng kinh nghiệm của nhân vật

        //Kiểm tra nếu kinh nghiệm vượt qua giới hạn MAX_EXPERIENCE thì tăng cấp
        if (experience >= MAX_EXPERIENCE)
        {
            LevelUp();
        }
    }

    //Hàm tăng cấp cho nhân vật
    private void LevelUp()
    {
        level++; //Tăng cấp
        experience = 0; //Reset kinh nghiệm về 0

        //Cập nhật thông số mới cho nhân vật
        health += 20;
        speed += 1;

        Debug.Log("Level Up!"); //Thông báo cho người chơi biết rằng nhân vật đã tăng cấp
    }
}
