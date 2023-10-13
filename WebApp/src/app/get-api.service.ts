import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetAPIService {

  //Urls para conectarse a la API
  private urlTestUrl = 'https://pokeapi.co/api/v2/pokemon/ditto';

  //Url para realizar consultas de un archivo en especifico 
  //private consutl:string = '';
  //private urlTestcUrl  = `https://pokeapi.co/api/v2/berry/?search=${this.consutl}`;

  //Constructor que crea un httpClient para poder realizar conecciones con la API
  constructor(private http: HttpClient) { }

  // Metodos de Post y Gets para la API
  getDataTest(): Observable<any> {
    return this.http.get<any>(this.urlTestUrl)
  }

  getDataTestc(i:string): Observable<any> {
    const urlTestcUrl  = `https://pokeapi.co/api/v2/berry/${i}`;
    return this.http.get<any>(urlTestcUrl)
  }

  getDataLocation(): Observable<any> {
    return this.http.get<any>(this.urlTestUrl)
  }
}
