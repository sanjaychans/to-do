import { LookupService } from '../lookup.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class lookupHelper {

  allLookups = new Array();

  constructor(private lookupService: LookupService) {

  }

  getLookup(tag?: string) {
    var lookups = new Array();
    var promise = new Promise((resolve, reject) => {
      this.lookupService.fetchLookup(tag).subscribe((data) => {
        data.forEach((val) => {
          lookups.push({
            id: val.id,
            name: val.name,
            code: val.code,
            tag: val.tag,
            sortIndex: val.sortIndex
          })
        })
        resolve(lookups);
      })
    });
    return promise;
  }

  getAll() {
    var promise = new Promise((resolve, reject) => {
      this.lookupService.fetchAllLookups().subscribe((data) => {
        data.forEach((val) => {
          this.allLookups.push({
            id: val.id,
            name: val.name,
            code: val.code,
            tag: val.tag,
            sortIndex: val.sortIndex
          })
        })
        resolve(this.allLookups);
      })
    });
    return promise;
  }


  getLookupName(code: string) {
    let list = this.allLookups.filter(function (entry) {
      return entry.code === code;
    });
    if (list.length > 0)
      return list[0].name;
  }


}
