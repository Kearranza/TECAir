package com.example.tecair_app.promos;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.example.tecair_app.R;

public class Promo2 extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_promo2);
    }
    public void onClickBack(View view) {
        Intent intent = new Intent(this, promosAdmin.class);
        startActivity(intent);
    }
}