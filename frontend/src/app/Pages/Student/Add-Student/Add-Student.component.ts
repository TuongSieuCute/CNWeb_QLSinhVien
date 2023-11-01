import { Component, OnInit } from '@angular/core';
import { QuanLyService } from 'src/app/Services/QuanLy.service'; // Import QuanLyService
import { Router } from '@angular/router';

@Component({
  selector: 'app-Add-Student',
  templateUrl: './Add-Student.component.html',
  styleUrls: ['./Add-Student.component.css']
})
export class AddStudentComponent implements OnInit {
  newStudent: any = {
    Masv: '',
    Hotensv: '',
    Gioitinh: '',
    Ngaysinh: '',
    Diachi: '',
    Sodienthoai: '',
    Email: '',
    Mak: ''
  };

  constructor(private quanLyService: QuanLyService, private router: Router) {}

  ngOnInit() {}

  addStudent() {
    const makNavigation = this.createMakNavigation(this.newStudent.Mak);
    this.newStudent.MakNavigation = makNavigation;

    this.quanLyService.create(this.newStudent).subscribe({
      next: (response) => {
        console.log('Thêm sinh viên thành công');
        this.router.navigate(['/student-list']);
      },
      error: (error) => {
        console.error('Lỗi khi thêm sinh viên', error);
      }
    });
  }
   createMakNavigation(mak: string) {
    let makNavigation: any = {};

    switch (mak) {
      case 'K01':
        makNavigation = {
          Mak: 'K01',
          Tenk: 'Công nghệ thông tin',
        };
        break;
      case 'K02':
        makNavigation = {
          Mak: 'K02',
          Tenk: 'Địa lý',
        };
        break;
      case 'K03':
        makNavigation = {
          Mak: 'K03',
          Tenk: 'Hóa học',
        };
        break;
      case 'K04':
        makNavigation = {
          Mak: 'K04',
          Tenk: 'Toán',
        };
        break;
      case 'K05':
        makNavigation = {
          Mak: 'K05',
          Tenk: 'Ngữ văn',
        };
        break;
    }

    return makNavigation;
  }
}
