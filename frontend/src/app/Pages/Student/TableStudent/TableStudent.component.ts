import { Component, OnInit } from '@angular/core';
import { QuanLyService } from 'src/app/Services/QuanLy.service';
import {SinhVien} from 'src/app/Models/SinhVien'

@Component({
  selector: 'app-TableStudent',
  templateUrl: './TableStudent.component.html',
  styleUrls: ['./TableStudent.component.css']
})
export class TableStudentComponent implements OnInit {
  SinhVienList: SinhVien[]=[];
  constructor(private service: QuanLyService) {}

  ngOnInit(): void {
    this.service.getSinhVien().subscribe({
      next:(list)=>{
        this.SinhVienList=list;
        list.forEach(item=>{
          console.log(item)
        })
      }
    })
  }
}
