package com.example.tecair_app.login;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.example.tecair_app.db.*;
import com.example.tecair_app.MainActivity;
import com.example.tecair_app.R;

import org.w3c.dom.Text;

public class loginAdmin extends AppCompatActivity{
    TextView user, pword;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login_admin);
        user = findViewById(R.id.user);
        pword = findViewById(R.id.Password);
    }

    public void onClickBack(View view) {
        Intent intent = new Intent(this, MainActivity.class);
        startActivity(intent);
    }

    public void onClickLogin(View view) {
        String username = user.getText().toString();
        String password = user.getText().toString();

        if(username.isEmpty()){
            user.setError("Este campo no puede quedar vacio");
            return;
        }
        if(password.isEmpty()){
            pword.setError("Este campo no puede quedar vacio");
            return;
        }
        dataBaseHelper db = new dataBaseHelper(loginAdmin.this);
        Boolean check = db.userExist(username, password);
        if(check){
            Toast.makeText(loginAdmin.this, "Bienvenido " + username, Toast.LENGTH_SHORT).show();
            Intent intent = new Intent(this, MainActivity.class);
            startActivity(intent);
        }
        Toast.makeText(loginAdmin.this, "Usuario no encontrado", Toast.LENGTH_SHORT).show();
    }
}