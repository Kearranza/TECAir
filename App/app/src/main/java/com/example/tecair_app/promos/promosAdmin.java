package com.example.tecair_app.promos;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import com.example.tecair_app.MainActivity;
import com.example.tecair_app.R;
import com.example.tecair_app.db.dataBaseHelper;

public class promosAdmin extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_promos_admin);
    }

    public void onClickBack(View view) {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }

    public void onClickPromo1(View view) {
        Intent intent = new Intent(this, Promo1.class);
        startActivity(intent);
    }

    public void onClickPromo2(View view) {
        Intent intent = new Intent(this, Promo2.class);
        startActivity(intent);
    }
    public void onClickPromo3(View view){
        Intent intent = new Intent(this, Promo3.class);
        startActivity(intent);
    }
}