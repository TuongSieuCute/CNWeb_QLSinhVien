import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SinhVien } from '../Models/SinhVien';

@Injectable({
  providedIn: 'root'
})
export class QuanLyService {
  private baseUrl = environment.apiUrl; // Sử dụng địa chỉ cơ sở từ environment.ts

  constructor(private http: HttpClient) { }

  getAllData(): Observable<any> {
    const url = `${this.baseUrl}${environment.path.home}`;
    return this.http.get(url);
  }

  getById(id: number): Observable<any> {
    const url = `${this.baseUrl}${environment.path.getById}/${id}`;
    return this.http.get(url);
  }

  search(keyword: string): Observable<any> {
    const url = `${this.baseUrl}${environment.path.search}?keyword=${keyword}`;
    return this.http.get(url);
  }

  create(data: any): Observable<any> {
    const url = `${this.baseUrl}${environment.path.create}`;
    return this.http.post(url, data);
  }

  edit(id: number, data: any): Observable<any> {
    const url = `${this.baseUrl}${environment.path.edit}/${id}`;
    return this.http.put(url, data);
  }

  delete(id: number): Observable<any> {
    const url = `${this.baseUrl}${environment.path.delete}/${id}`;
    return this.http.delete(url);
  }
}
