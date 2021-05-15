class PurchaseController < ApplicationController
  before_action :check_session
  skip_before_action :check_session, only: [:session_fail]
  
  def add_money
    render :json => { success: true, money: 9999 }
  end

  def session_fail
    render :json => { success: false }
  end

  def check_session
    if session[:id] != nil
      redirect_to action: :session_fail
    end
  end
end
