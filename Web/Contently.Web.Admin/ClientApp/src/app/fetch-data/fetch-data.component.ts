import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
    public contentTypes: ContentType[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      http.get<ContentType[]>(baseUrl + 'AdminController/GetContentTypes').subscribe(result => {
          this.contentTypes = result;
    }, error => console.error(error));
  }
}

interface ContentType {
    contentType: string;
}
