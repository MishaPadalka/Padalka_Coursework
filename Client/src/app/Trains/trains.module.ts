import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrainsContainerComponent } from './trains-container/trains-container.component';
import { FullTrainComponent } from './full-train/full-train.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './../app-routing.module';

@NgModule({
  declarations: [TrainsContainerComponent, FullTrainComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    AppRoutingModule
  ]
})
export class TrainsModule { }
