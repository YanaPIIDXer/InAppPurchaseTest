class PurchaseController < ApplicationController
  before_action :check_session
  skip_before_action :check_session, only: [:session_fail, :test]
  
  require 'net/https'
  require 'uri'
  require 'json'
  
  def add_gold
    # UnityのAPIの関係でパラメータ名の先頭は大文字
    store = params["Store"]
    payload = params["Payload"]
    verify = send_verify_request(store, payload)

    user = User.find_by(id: session[:id])
    gold = user.gold
    if verify then
      user.gold += 100
      gold = user.gold
      user.save()
    end

    render :json => { success: verify, gold: gold }
  end

  def session_fail
    render :json => { success: false }
  end

  def check_session
    if session[:id] == nil
      redirect_to action: :session_fail
    end
  end

  def test
    status = send_verify_request("test", "test")
    render :json => status
  end

  def send_verify_request(store, payload)
    result = false
    if store == "GooglePlay" then
      result = send_verify_request_android(payload)
    elsif store == "AppleAppStore" then
      result = send_verify_request_ios(payload)
    else
      result = true
    end

    return result
  end

  def send_verify_request_ios(payload)
    uri = URI.parse("https://sandbox.itunes.apple.com/verifyReceipt")
    http = Net::HTTP.new(uri.host, uri.port)
    http.use_ssl = true
    params = {"receipt-data": payload, password: "password"}
    header = {"Content-Type"=> "application/json"}
    response = http.post(uri.path, params.to_json(), header)
    return response.body["status"] == 0
  end

  def send_verify_request_android(payload)
    # TODO:レシート検証方法の調査
    return false
  end
end
