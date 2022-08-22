import { Component, Input, OnInit } from '@angular/core';
import { Subject } from 'rxjs';
import { SpinnerOverlayService } from '../../services/spinner-overlay.service';

@Component({
  selector: 'app-spinner-overlay',
  templateUrl: './spinner-overlay.component.html',
  styleUrls: ['./spinner-overlay.component.css']
})
export class SpinnerOverlayComponent implements OnInit {
  // isLoading: Subject<Boolean> = this.overlayService.isLoading;

  constructor() { }

  ngOnInit(): void {
  }

}
