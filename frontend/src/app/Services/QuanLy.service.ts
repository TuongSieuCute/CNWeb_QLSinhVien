import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SinhVien } from '../Models/SinhVien';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class QuanLyService {

  constructor(private httpClient: HttpClient) { }

  getSinhVien(){
    return this.httpClient.get<SinhVien[]>("http://localhost:5183/Home/GetSinhVien");
  }

  delete(masv: string): Observable<any> {
    return this.httpClient.delete<any>("http://localhost:5183/Home/GetSinhVien/" + masv);
  }
}
