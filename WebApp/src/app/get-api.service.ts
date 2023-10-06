import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetAPIService {

  //Urls para conectarse a la API
  private urlTestUrl = 'https://pokeapi.co/api/v2/pokemon/ditto';

  //Constructor que crea un httpClient para poder realizar conecciones con la API
  constructor(private http: HttpClient) { }

  // Metodos de Post y Gets para la API
  getDataTest(): Observable<any> {
    return this.http.get<any>(this.urlTestUrl)
  }

}
