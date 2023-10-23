package com.example.tecair_app.promos;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.example.tecair_app.R;
import com.example.tecair_app.flights.basicRegister;
import com.example.tecair_app.promos.promosAdmin;

public class Promo1 extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_promo1);
    }

    public void onClickBack(View view) {
        Intent intent = new Intent(this, promosAdmin.class);
        startActivity(intent);
    }

    public void goToBR(View view) {
        Intent intent = new Intent(this, basicRegister.class);
        startActivity(intent);
    }
}