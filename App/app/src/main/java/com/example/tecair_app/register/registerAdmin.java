package com.example.tecair_app.register;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.example.tecair_app.MainActivity;
import com.example.tecair_app.R;

public class registerAdmin extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_register_admin);
    }

    public void onClickBack(View view) {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }

    public void onClickUser(View view) {
        Intent intent = new Intent(this, userRegister.class);
        startActivity(intent);
    }

    public void onClickStudent(View view) {
        Intent intent = new Intent(this, studentRegister.class);
        startActivity(intent);
    }
}