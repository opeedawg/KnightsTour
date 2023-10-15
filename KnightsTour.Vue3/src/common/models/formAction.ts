import { SystemColor } from './global';

/** A restriction status applied to a field */
export class FormAction {
  id: string;
  label: string;
  textColor: string;
  backgroundColor: string;
  sendData: boolean;
  icon: string;

  constructor(
    id: string,
    label: string,
    sendData?: boolean,
    icon?: string,
    textColor?: string,
    backgroundColor?: string
  ) {
    this.id = id;
    this.label = label;
    this.textColor = SystemColor.White;
    if (textColor != null) {
      this.textColor = textColor;
    }
    this.backgroundColor = SystemColor.Primary;
    if (backgroundColor != null) {
      this.backgroundColor = backgroundColor;
    }
    this.sendData = true;
    if (sendData != null) {
      this.sendData = sendData;
    }
    this.icon = '';
    if (icon != null) {
      this.icon = icon;
    }
  }
}
