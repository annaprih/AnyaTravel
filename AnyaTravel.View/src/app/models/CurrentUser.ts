/**
 * Created by annae on 02.04.2018.
 */
export class CurrentUser {
  public id: string;
  public roles: Array<string> = new Array<string>();
  public isAuntificated: boolean;
  public fIO: string;
  public birthday: string;
  public email: string;
  public login: string;
}
