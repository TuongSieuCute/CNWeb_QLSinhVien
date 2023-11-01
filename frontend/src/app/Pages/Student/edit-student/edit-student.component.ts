import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { QuanLyService } from 'src/app/Services/QuanLy.service';

@Component({
  selector: 'app-edit-student',
  templateUrl: './edit-student.component.html',
  styleUrls: ['./edit-student.component.css']
})
export class EditStudentComponent {
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

  constructor(private quanLyService: QuanLyService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe((params) => {
      const studentId = params['id'];

      if (studentId) {
        this.quanLyService.getById(studentId).subscribe({
          next: (studentData) => {
            console.log(studentData);

            const date = new Date(studentData.ngaysinh);
            date.setDate(date.getDate() + 1);

            const formattedDate = date.toISOString().substring(0, 10);

            this.newStudent = {
              Masv: studentData.masv,
              Hotensv: studentData.hotensv,
              Gioitinh: studentData.gioitinh,
              Ngaysinh: formattedDate,
              Diachi: studentData.diachi,
              Sodienthoai: studentData.sodienthoai,
              Email: studentData.email,
              Mak: studentData.mak,
            };

            console.log(this.newStudent);
          },
          error: (error) => {
            console.error('Lỗi khi lấy dữ liệu sinh viên', error);
          }
        });
      }
    });
  }

  updateStudent() {
    const makNavigation = this.createMakNavigation(this.newStudent.Mak);
    this.newStudent.MakNavigation = makNavigation;

    this.quanLyService.edit(this.newStudent.Masv, this.newStudent).subscribe({
      next: (response) => {
        console.log('Cập nhật sinh viên thành công');
        this.router.navigate(['/student-list']); // Redirect back to the student list page after the update
      },
      error: (error) => {
        console.error('Lỗi khi cập nhật sinh viên', error);
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
