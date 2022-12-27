import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  constructor(private http: HttpClient) {   }
  httpOption = {
    header: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  readonly ApiUrl = environment.apiBase;
  getData():Observable<any[]>{         
    return this.http.get<any>(this.ApiUrl+'/users/GetUsers');  
  } 

  saveUserMaster(val:any){
    return this.http.post(this.ApiUrl+'/CreateUser',val);
  }

  updateUser(val:any){
    return this.http.put(this.ApiUrl+'/UpdateUser',val);
  }

  deleteUser(val:any){
    return this.http.delete(this.ApiUrl+'/DeleteUser',val);
  }
  
  authUser(val: any){
    return this.http.post<any>(this.ApiUrl + '/users/Login',val);
  }
}
