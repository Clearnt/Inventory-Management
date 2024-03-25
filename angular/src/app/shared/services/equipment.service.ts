import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { EquipmentModel } from '../models/equipment.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EquipmentService {

  url: string = environment.apiUrlBase + "/EquipmentRecords";

  constructor(private http: HttpClient) { }

  createEquipment(eq: EquipmentModel) : Observable<EquipmentModel> {
    return this.http.post<EquipmentModel>(this.url, eq);
  }

  getEquipment() : Observable<EquipmentModel[]> {
    return this.http.get<EquipmentModel[]>(this.url);
  }

  getEquipmentId(id: Number) : Observable<EquipmentModel> {
    return this.http.get<EquipmentModel>(`${this.url}/${id}`);
  }

  updateEquipment(eq: EquipmentModel) : Observable<EquipmentModel> {
    return this.http.put<EquipmentModel>(`${this.url}/${eq.id}`, eq);
  }

  deleteEquipment(id: Number) : Observable<void> {
    return this.http.delete<void>(`${this.url}/${id}`);
  }
}
